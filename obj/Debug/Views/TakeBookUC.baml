   M S B A M L   `   `   `  ????H  DADO.NET_Task4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ADO.NET_Task4.ViewsADO.NET_Task4.Views  5      $    ADO.NET_Task4.Views.TakeBookUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ADO.NET_Task4.Views     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6>   h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6?   .??5	      ?? 
???????.+?5
   
   ?? $??60??6     ?? Orientation$  
Horizontal=?5      .+?5      ?? $??50??6   $??5q?5      $	??105??5         MyButtonStyle#??[  5      $
??Left=?5      ??5      ?? *BackCommand+??5      ?? 5      .+?5      ?? $??\Images\back.png??6    $??40??5       $??40??5        ?? Left$	 -50??5       
 ?? Top$	 -20??5       5      ?? 5      $??Cascadia Code SemiBold)?6$   $??20(?5   $   $
??Back??5   $   $	 -12??5   $   5      5      5!      ?? 5#      $??\Images\book.png??6   $??40??5$      $??40??5%      $??	190,0,0,0q?5&      5'      ?? 5(      $??Cascadia Code SemiBold)?6   $??30(?5)      $??	Rent Book??5*      $	??160??5+      $??40??5,      5-      5.      ?? 50   
   $	??100??6   .+?51      ??  ?? CornerRadius$ 5??6   $??Center=?52      $??Center=?53      $
??Auto??54      $??0,20,0,0q?55      
???   ?$??2q?57      $
??Auto??6)   ._?58      ?? -   5         ??Name$ 
BookNameTB??5;      $??Cascadia Code SemiBold)?58      $??Center=?59      $??25(?5:      $
??Wrap=?5<      ???#4538CD??5=      ?? *	Book.Name+5>      5?      5@      ?? 5B   
   $	??650??6   $  
Horizontal=?5C      .+?5D      ?? $	??370??6   .+?5E      ??   MyTextBlockStyle#??[ 6   $??Enter your student ID   :??5F      $	??305??6=   5G      ?? 5I      #??[ 6   $??Enter day count         :??5J      $	??305??6=   5K      5M      ?? 5N      .+?5O      ??   MyTextBoxStyle#??[ 6   ??5P      ?? *	StudentId+ ?? Mode$ OneWayToSource=?.??6J   .  (System.Windows.Interactivity.Interaction   Triggers 5Q      /  )System.Windows.Interactivity.EventTrigger  5R         	EventName$ PreviewTextInput??6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5S      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction  	   
MethodName$	 IsAllowedInput??6K   
   TargetObject
 62   ?? 6K   5T      .??5U   .   5V      ?? 5W      #??[ 6   ??5X      ?? *
DayCount+$ OneWayToSource=?.??6I    5Y        5Z      $ PreviewTextInput??6)   . 5[        $	 IsAllowedInput??6K   
 62   ?? 6K   5\      .??5]   .   5^      5_      5`      ?? 5b   
   .+?5c      ?? #??[  6   $??Rent The Book??5e      $	 265??6-   $
 -470??6?   $
??Left=?6Q   $	??Top=?6l   $	??275??6?   ??5d      ?? *RentBookCommand+5f      5g      5h      5i      