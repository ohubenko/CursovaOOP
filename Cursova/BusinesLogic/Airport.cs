using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Int32;

namespace Cursova
{
    /// <summary>
    /// Класс аєропорту, композиція з списку стойок, черги на виліт, черга літаків які готові на виліт
    /// Черга з стюардес
    /// </summary>
    public class Airport
    {
        private List<ServiceFrontDesk> _frontDesks;

        private ConcurrentQueue<Passanger> _passangersWithTicket;
        private Queue<Passanger> _passangersForArrival;
        private Queue<Airplane> _airplanes;
        private Queue<Stewardess> _stewardesses;

        #region Labels

        private Label _labelCountAirplane;
        private Label _labelCountStewardess;
        private Label _labelCountDesk;
        private Label _labelCountFirstClassDesk;
        private Label _labelCountSecondClassDesk;
        private Label _labelCountHumanInQueue;
        private Label _labelSkippedHuman;
        public int CriticalSize;

        #endregion

        #region Initialization

        public Airport(Label labelCountAirplane, Label labelCountStewardess, Label labelCountDesk,
            Label labelCountFirstClassDesk, Label labelCountSecondClassDesk, Label labelCountHumanInQueue,
            Label skippedHuman)
        {
            loadLabel(labelCountAirplane, labelCountStewardess, labelCountDesk, labelCountFirstClassDesk,
                labelCountSecondClassDesk, labelCountHumanInQueue, skippedHuman);
            InitCollection();
        }

        private void InitCollection()
        {
            _airplanes = new Queue<Airplane>();
            _frontDesks = new List<ServiceFrontDesk>();
            _passangersWithTicket = new ConcurrentQueue<Passanger>();
            _passangersForArrival = new Queue<Passanger>();
            _stewardesses = new Queue<Stewardess>();
        }

        private void loadLabel(Label labelCountAirplane, Label labelCountStewardess, Label labelCountDesk,
            Label labelCountFirstClassDesk, Label labelCountSecondClassDesk, Label labelCountHumanInQueue,
            Label skippedHuman)
        {
            _labelCountAirplane = labelCountAirplane;
            _labelCountStewardess = labelCountStewardess;
            _labelCountDesk = labelCountDesk;
            _labelCountFirstClassDesk = labelCountFirstClassDesk;
            _labelCountSecondClassDesk = labelCountSecondClassDesk;
            _labelCountHumanInQueue = labelCountHumanInQueue;
            _labelSkippedHuman = skippedHuman;
        }

        #endregion

        public async void process()
        {
            await StartGenerationAirplane();
            Thread.Sleep(5000);
            await StartGenerationHuman();
            Thread.Sleep(10_000);
        }

        public async void startSell()
        {
            foreach (ServiceFrontDesk serviceFrontDesk in _frontDesks)
            {
                await Task.Run(() => serviceFrontDesk.sellTicket(_passangersWithTicket));
            }
        }

        public async Task StartGenerationHuman()
        {
            await Generator.GeneratePassanger(_frontDesks, _labelCountHumanInQueue, _labelSkippedHuman);
        }

        public async Task StartGenerationAirplane()
        {
            await Generator.GenerateAirplane(_airplanes, _labelCountAirplane);
        }

        public void StartPlane()
        {
            var thread = new Thread(() =>
            {
                if (_airplanes.Count > 1)
                {
                    if (_frontDesks.Count > 0 && _passangersWithTicket.Count > 0)
                    {
                        int countPassangers = _passangersWithTicket.Count / _frontDesks.Count;
                        foreach (var desk in _frontDesks)
                        {
                            for (int i = 0; i < countPassangers; i++)
                            {
                                Passanger passanger;
                                while (_passangersWithTicket.TryDequeue(out passanger))
                                    desk.register(passanger, _passangersForArrival);
                            }
                        }

                        _airplanes.Dequeue();
                        var lac = Parse(_labelCountAirplane.Text);
                        lac--;
                        _labelCountAirplane.Invoke(new Action(() => { _labelCountAirplane.Text = lac.ToString(); }));
                        StatisticStorage.addTotalFlying(countPassangers * _frontDesks.Count);
                    }
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }


        public void AddStewardes()
        {
            Stewardess stewardess = new Stewardess("Stewardess", "Worker");
            _stewardesses.Enqueue(stewardess);
            changeCount(_labelCountStewardess);
        }

        public void AddServiceDesk(int num)
        {
            if (_stewardesses.Count > 0)
            {
                switch (num)
                {
                    case 0:
                        _frontDesks.Add(new FisrtClassServiceDesk(_stewardesses.Dequeue()));
                        changeCount(_labelCountFirstClassDesk);
                        break;
                    case 1:
                        _frontDesks.Add(new SecondClassServiceDesk(_stewardesses.Dequeue()));
                        changeCount(_labelCountSecondClassDesk);
                        break;
                    default:
                        _frontDesks.Add(new SecondClassServiceDesk(_stewardesses.Dequeue()));
                        changeCount(_labelCountSecondClassDesk);
                        break;
                }

                _labelCountDesk.Text = _frontDesks.Count.ToString();
            }
            else
            {
                MessageBox.Show("No stewardess to service this desk");
            }
        }

        private void changeCount(Label label)
        {
            var i = Parse(label.Text);
            i++;
            label.Invoke(new Action(() => label.Text = i.ToString()));
        }

        public void AddHuman()
        {
            int size = _frontDesks.Count != 0 ? _frontDesks.Sum(desk => desk.sizeQueue()) : 0;
            if (_frontDesks.Count > 0 && CriticalSize < size )
            {
                ServiceFrontDesk minimalDesk = _frontDesks.OrderBy(desk => desk.sizeQueue()).First();
                minimalDesk.add(new Human("Passanger", "random"));
                _labelCountHumanInQueue.Invoke(new Action(() =>
                {
                    _labelCountHumanInQueue.Text = GetTotalSizeQueueToDesks().ToString();
                }));
            }
            else
            {
                var i = Parse(_labelSkippedHuman.Text);
                i++;
                _labelSkippedHuman.Invoke(new Action(() => _labelSkippedHuman.Text = i.ToString()));
            }
        }

        public int GetTotalSizeQueueToDesks()
        {
            return _frontDesks.Sum(desk => desk.sizeQueue());
        }
    }
}