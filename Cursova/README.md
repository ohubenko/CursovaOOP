1. Система моделювання продажу квитків в аеропорті.  
   У курортному аеропорті малої авіації до продажу квитків залучено стюардес. На продаж квитка стюардеса витрачає
   випадковий час.  
   Друге завдання стюардеси - проводити групи пасажирів до літаків, які чекають завантаження, тому періодично стюардеси
   йдуть із групою пасажирів на літовище. А якщо літака нема, пасажири чекають. В аеропорті обмежена кількість малих
   літаків, які летять і повертаються. Якщо довжина всіх черг на покупку квитків до вільних стюардес перевищують
   критичне значення, пасажир іде на залізничний вокзал.

2. Основні класи:

- Пасажр
- стюардесса,
- літак,
- литовище
- квиток.

Композиція:

- Пасажир - група псажирів;
- Літак - литовище/аєропорт

Flow:  
Стюардеса:

- Продаж квитків
- Проведення групи пасажирів до літаків, які чекають на завантаження

Пасажир:

- Купівля квитка
- Посадка в літак
- Очікування
- Покинути литовище

Літак:

- Прибуття на литовище
- Очікування пасажирів
- Виліт

Аєропорт:

- Обмежена кількість літаків
- Черга на покупку квитків

Обслуговування пасажирів:

- Стюардеса
    - Витрачає випадковий час
    - Знаходиться за стійкою
- Пасажир
    - Стає в чергу
    - Купує квиток

Generator - Створення через випадкові інтервали часу транзакції і додавати їх до черги

Notes:
Generator, Device, Transaction, Queue

Запуск моделі:

```c#
//Готуємо діаграму для виведення графіку
getDiagramQueue().clear();
//Створюємо диспетчера
Dispatcher dispatcher = new Dispatcher();
//Створюємо модель за допомогою фабрики
IModelFactory factory = (d)-> new Model(d, this);
Model model =(Model) factory.createModel(dispatcher);
// Робимо кнопку «Старт» недосяжною на період роботи моделі
getJButtonStart().setEnabled(false);
dispatcher.addDispatcherFinishListener(
()->getJButtonStart().setEnabled(true));
//Готуємо модель до роботи у режимі тестування
model.initForTest();
//Запускаємо модель
dispatcher.start();
```

Сама модель:

```c#
//Посилання на диспетчера
private Dispatcher dispatcher;
//Посилання на візуальну частину
private GUI gui;
////////Актори\\\\\\\\\
// Генератор транзакцій
private Generator generator;
// Обслуговуючий прилад
private Device device;
//Бригада обслуговуючих пристроїв
private MultiActor multiDevice;
/////////Черги\\\\\\\\\
// Черга транзакцій
private QueueForTransactions<Transaction> queue;
```

Конструктор моделі:

```c#
public Model(Dispatcher d, GUI g) {
if (d == null || g == null) {
System.out.println("Не визначено диспетчера або GUI для Model");
System.out.println("Подальша робота неможлива");
System.exit(0);
}
dispatcher = d;
gui = g;
//Передаємо акторів до стартового списку диспетчера
componentsToStartList();
}
```

Метод componentsToStartList:

```c#
public void componentsToStartList() {
// Передаємо акторів диспетчеру
dispatcher.addStartingActor(getGenerator());
dispatcher.addStartingActor(getMultiDevice());
```

Метод відкладеного створення бригади пристроїв

```c#
public MultiActor getMultiDevice() {
if (multiDevice == null) {
multiDevice = new MultiActor();
multiDevice.setNameForProtocol("MultiActor для бригади пристроїв");
multiDevice.setOriginal(getDevice());
multiDevice.setNumberOfClones(gui.getChooseDataNdevice().getInt());
}
return multiDevice;
}
```

Actor Цей абстрактний клас містить найбільш загальні властивості й методи об'єктів, які мають правила дії, розподілені в
часі. Клас реалізує два інтерфейси. Інтерфейс Runnable дає можливість виконувати правила дії об'єктів як потоки.
Відповідно до вимог цього інтерфейсу в класі реалізований метод run(), що забезпечує запуск правил дії об'єктів
підкласів. Інтерфейс Clonable дає можливість клонувати об'єкти класу або його підкласів. Відповідно до вимог цього
інтерфейсу в класі реалізований метод clone(). Особливості клонування об'єктів в Java розглядалися вище, при розгляді
класу MultyActor. Поле activateCondition зберігає посилання на об'єкт типу BooleanSupplier, що у вигляді методу
getAsBoolean() містить умову, виконання якої чекає призупинений об'єкт. Поле activateTime, типу double, містить час
поновлення виконання правил дії, призупинених на якийсь час. Поле dispatcher містить посилання на об'єкт класу
Dispatcher, під керуванням якого будуть виконуватися правила дії об'єкта. Поле nameForProtocol містить ім'я об'єкту, що
використовується у протоколі роботи моделі. Поле suspendIndicator містить посилання на об'єкт класу BooleanSemaphore і
використовується для призупинення та відновлення правил дії. Поле waitingTimeHisto призначено для зберігання посилання
на об'єкт класу Histo. Якщо таке посилання передано актору, то у відповідній гістограмі буде накопичуватися інформація
про час чекання актора. Для доступу до полів є методи, названі у відповідності зі стандартними правилами.

Текст методу run() класу Actor

```c#
public void run() {
dispatcher.printToProtocol(" " + nameForProtocol + " стартує");
try {
rule();
} catch (DispatcherFinishException e) {
dispatcher.printToProtocol(" " + nameForProtocol
+ " не дочекався, бо диспетчер закінчив роботу.");
return;
} finally {
dispatcher.printToProtocol(" " + nameForProtocol + " роботу завершив");
// Переводимо індикатор у стан "Актора призупинено" і таким чином
повідомляємо "Диспетчера", що виконання правил дії даного "актора"
// завершено, що дає можливість "Диспетчеру" продовжити роботу
suspendIndicator.setValue(true);
}
}
```

Текст методу holdForTime(double) класу Actor:

```c#
protected final void holdForTime(double holdTime) {
// Затримка не має сенсу, якщо диспетчер закінчив роботу.
if (!dispatcher.isActiv()) {
return;
}
// Обчислюємо час відновлення правил дії "актора"
activateTime = dispatcher.getCurrentTime() + holdTime;
// Заносимо посилання на "актора"
// у список акторів, що затримані на деякий час.
dispatcher.getTimingActorQueue().add(this);
dispatcher.printToProtocol(" " + getNameForProtocol()
+ " затриманий до " + activateTime);
// Переводимо індикатор у стан "Актора призупинено",
// внаслідок чого "Диспетчер" може продовжити работу.
suspendIndicator.setValue(true);
// Призупиняємо потік виконання правил дії "актора"
suspendIndicator.waitForValue(false);
// Тут актор колись відновить виконання правил дії
dispatcher.printToProtocol(" " + getNameForProtocol()
+ " активізувався ");
}
```

Метод waitForCondition(BooleanSupplier, String) класу Actor:

```c#
protected final void waitForCondition(BooleanSupplier c, String s)
throws DispatcherFinishException {
// Якщо умова виконується, затримка не потрібна
if (c. getAsBoolean() )
return;
// Якщо диспетчер закінчив роботу, затримка не має сенсу.
if (!getDispatcher().getThread().isAlive()) {
return;
}
// Зберігаємо об’єкт, що містить умову.
activateCondition = c;
// Передаємо "актора" до списку акторів
// що затримані до виконання умови
getDispatcher().getWaitingActorQueue().add(this);
getDispatcher().printToProtocol(
" " + getNameForProtocol() + " чекає '"+ s + "'");
//Запам'ятовуємо час, коли почалося чекання
double stopTime=dispatcher.getCurrentTime();
// Переводимо індикатор у стан "Актора призупинено",
// надаючи "Диспетчеру" можливість працювати
suspendIndicator.setValue(true);
// Переводимо потік виконання правил дії "актора"
// у стан чекання.
// Коли умова виконується,
// диспетчер перемикає індикатор у стан false
suspendIndicator.waitForValue(false);
if(waitingTimeHisto!=null)
//Обчислюємо і передаємо до гістограми час чекання
waitingTimeHisto.add(dispatcher.getCurrentTime()-stopTime);
if (activateCondition. getAsBoolean())
getDispatcher().printToProtocol(
" " + getNameForProtocol() + " дочекався '"+ s + "'");
else
throw new DispatcherFinishException();
}
```

Клас Dispatcher:

- currentTime – поточне значення модельного часу.
- startList – список об'єктів, правила дії яких диспетчер повинен активізувати. На початку роботи цей список повинен
  містити посилання хоча б на один об'єкт, яким повинен керувати диспетчер. Поповнення цього списку можливо за допомогою
  методу addStartingActor(Actor).
- timingActorQueue – список майбутніх подій, де перебувають посилання на об'єкти, правила дії яких припинені на деякий
  час. На початку цього списку має бути актор з найменшим часом поновлення правил дії. Це забезпечується об’єктом типу
  Comparator, який порівнює час активізації акторів.
- waitingActorQueue – список посилань на об'єкти, у яких правила дії припинені до виконання деяких умов. Об'єкти в цьому
  списку впорядковані по правилу FIFO.
- protocolFileName – рядок, що визначає ім'я файлу, куди буде виводиться протокол роботи моделі. Якщо ця змінна має
  значення “Console”, протокол виводиться на консоль. Якщо значення цієї змінної пустий рядок, протокол не виводиться.
- thread – посилання на потік виконання правил дії диспетчера.
- active – поле логічного типу, що має значення true, поки диспетчер працює. Перед закінченням роботи «диспетчер»
  установлює значення поля  
  

  Правила дії об'єкта класу Dispatcher:

```c#
public void run() {
activ = true;
currentTime = 0;
printToProtocol("Час " + currentTime);
Actor readyActor=null;
while (true) {
runStartList();
readyActor = testWaitingQueue();
if (readyActor == null) {
if (timingActorQueue.isEmpty()) {
break;
}
readyActor = timingActorQueue.remove(); setCurrentTime(readyActor.getActivateTime());
}
readyActor.getSuspendIndicator().setValue(false);
readyActor.getSuspendIndicator().waitForValue(true);
}
activ = false;
releaseWaitingQueue();
fireDispatcherFinishEvent(new DispatcherFinishEvent(this));
}
```

Метод runStartList() класу Dispatcher:

```c#
private void runStartList() {
while (!startList.isEmpty()) {
Actor a = startList.remove(0);
a.getSuspendIndicator().setValue(false);
a.start();
a.getSuspendIndicator().waitForValue(true);
}
}
```

Метод testWaitingQueue() для обробки списку об'єктів, що чекають виконання умов:

```c#
private Actor testWaitingQueue() {
Iterator i = this.waitingActorQueue.iterator();
while (i.hasNext()) {
Actor a = i.next();
if (a.activateCondition.getAsBoolean()) {
waitingActorQueue.remove(a);
timingActorQueue.remove(a);
return a;
}
}
return null;
}
```

Метод releaseWaitingQueue(), що звільняє списки об'єктів, що чекають виконання умов:

```c#
private void releaseWaitingQueue() {
printToProtocol(" Диспетчер звільняє потоки,
що чекають виконання умови");
while (waitingActorQueue.size()>0) {
Actor a = waitingActorQueue.remove(0);
a.getSuspendIndicator().setValue(false);
//Будемо чекати, поки не завершиться виконання правил дії
a.getSuspendIndicator().waitForValue(true);
}
}
```

**Абстракції**  
*Клас транзакції:(Пасажир)*
Транзакція має стати у чергу на обслуговування та фіксувати інтервали часу, коли вона перебувала у черзі та повний час
обслуговування.  
Атрибути:

- createTime double Час появи транзакції у системі Dispather
- serviceDone boolean Ознака завершення обслуговування Device
- queue QueueForTransaction Посилання на чергу транзакцій Model

*Клас генератор транзакцій(Генератор пасажирів)*
Головне завдання цієї абстракції – через випадкові інтервали часу створювати транзакції та передавати їх диспетчеру.
Свої дії об’єкт має виконувати впродовж усього часу моделювання.

- model Model Посилання на модель системи Model
- rnd Randomable Генератор випадкових чисел GUI
- finishTime double Час моделювання GUI

*Клас обслуговуючий пристрій(Стюардеса)*
Обслуговуючий пристрій працює із чергою транзакцій. Якщо черга пуста, обслуговуючий пристрій чекає на появу транзакції.
Якщо транзакція є, пристрій забирає її з черги для обслуговування. Далі обслуговуючий пристрій імітує обробку транзакції
шляхом затримки на деякий час. Після цього пристрій повідомляє транзакцію про завершення обслуговування. Далі правила
дії повторюються. Пристрій працює впродовж усього часу моделювання.

- queue QueueForTransaction Посилання на чергу транзакцій Model
- rnd Randomable Посилання на генератор випадкових чисел Gui
- finishTime double Час моделювання Gui

**Реалізації:**  
*Клас Transaction:*

```c#
public class Transaction extends Actor {
private double createTime;
private QueueForTransactions<Transaction> queue;
private Histo histoQueue;
private Histo histoService;
private boolean serviceDone;
public Transaction(Model model) {
this.queue = model.getQueue();
this.histoQueue = model.getHistoTransactionWaitInQueue();
this.histoService = model.getHistoTransactionServiceTime();
}
public double getCreateTime() {
return createTime;
}
public void setServiceDone(boolean b) {
this.serviceDone = b;
}
@Override
public String toString() {
return "Transaction " + createTime;
}
@Override
protected void rule() throws DispatcherFinishException {
createTime = dispatcher.getCurrentTime();
nameForProtocol = "Транзакція " + createTime;
queue.add(this);
waitForCondition(() -> !queue.contains(this), "мають забрати на обслуговування");
histoQueue.add(dispatcher.getCurrentTime() - createTime);
waitForCondition(() -> serviceDone, "мають завершити обслуговування");
histoService.add(dispatcher.getCurrentTime() - createTime);
}
```

*Клас Generator:*  
```c#
public class Generator extends Actor {
//Посилання на модель системи
private Model model;
// Генератор випадкового часу створення транзакції
private Randomable rnd;
// Тривалість роботи генератора
private double finishTime;
// Конструктор
public Generator(String name, GUI gui, Model model) {
setNameForProtocol(name);
this.model = model;
finishTime = gui.getChooseDataFinishTime().getDouble();
rnd = gui.getChooseRandomGen();
}
// Правила дії
public void rule() {
while (getDispatcher().getCurrentTime() <= finishTime) {
holdForTime(rnd.next());
getDispatcher().printToProtocol(
" " + getNameForProtocol() + " створює транзакцію.");
Transaction transaction = new Transaction(model);
dispatcher.addStartingActor(transaction);
}
}
}
```

*Клас Device*
```c#
public class Device extends Actor {
// Черга для тразакцій
private QueueForTransactions<Transaction> queue;
// Генератор часу, що витрачає прилад на обслуговування транзакції
private Randomable rnd;
// Час роботи генератора
private double finishTime;
// Конструктор, у якому ініціалізуються усі поля класу
// через доступ до моделі та візуальної частини
public Device(String name, GUI gui, Model model) {
setNameForProtocol(name);
finishTime = gui.getChooseDataFinishTime().getDouble();
rnd = gui.getChooseRandomDev();
queue = model.getQueue();
}
public void rule() throws DispatcherFinishException {
// Створюємо умову, виконання якої буде чекати актор
BooleanSupplier queueSize = () -> queue.size() > 0;
// цикл виконання правил дії
while (getDispatcher().getCurrentTime() <= finishTime) {
// Перевірка наявності транзакції та чекання на її появу
waitForCondition(queueSize, "у черзі має з'явиться транзакція");
Transaction transaction = queue.removeFirst();
// Імітація обробки транзакції
holdForTime(rnd.next());
transaction.setServiceDone(true);
}
}
```
