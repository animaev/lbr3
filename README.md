Практическая работа №3 по Разработке программных модулей WPF C#
Организация взаимодействия между окнами
Метод: Фреймы
1) Использование фрейма.
На этом этапе будем считать, что у нас уже сделаны два окна –
авторизация (AvtorizationWindow) и создание сотрудника (CreateWindow).
Для того, чтобы пользоваться фреймом, необходимо сделать вместо этих
окон аналогичные страницы – AvtorizationPage и CreatePage путем
копирования в xaml и всех методов в xaml.cs.
Для того, чтобы сделать переход из страницы AvtorizationPage на
страницу CreatePage необходимо:
1. В MainWindow.xaml создать Frame и присвоить ему имя (Например
FrameName).
2. В MainWindow.xaml.cs, после инициализации окна указать, что во
фрейме будет открываться страница AvtorizationPage. Делается это
следующей командой: FrameName.Navigate(new AvtorizationPage());
3. При нажатии на кнопку входа, если логин и пароль введены верно, во
фрейме должна открыться страница CreatePage. Для этого необходимо
прописать событие для кнопки: 
NavigationService nav = NavigationService.GetNavigationService(this);
nav.Navigate(new CreatePage());
Так же, по аналогии, в CreatePage необходимо сделать кнопку «Выход»,
которая бы возвращала пользователя на страницу авторизации.
Результат работы:
![image](https://user-images.githubusercontent.com/47950997/159159697-8f1377a8-1a20-4a5c-9b03-7ab13620aa6d.png)
![image](https://user-images.githubusercontent.com/47950997/159159712-2577d6a8-8093-48f3-a482-649530d5d76f.png)
![image](https://user-images.githubusercontent.com/47950997/159159753-a3c0b16a-6f75-4498-84f1-9832aa54ab6c.png)
![image](https://user-images.githubusercontent.com/47950997/159159782-26b649e1-cb71-4536-bfc5-1d67dae78bbb.png)
![image](https://user-images.githubusercontent.com/47950997/159159792-21a79e1c-8898-4752-9d15-7842965a2ee0.png)
