   M S B A M L   `   `   `  ����G  CChat_WpfAppt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Chat_WpfApptChat_WpfAppt  5   	   G(clr-namespace:Chat_WpfAppt.MVM.ViewModelChat_WpfAppt.MVM.ViewModel  62       Chat_WpfAppt.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Chat_WpfAppt     5   	   >	viewmodel(clr-namespace:Chat_WpfAppt.MVM.ViewModel     62   $	��650��5   	   $
��1200��6   ���#36393f  � WindowStyle$
  None=�5
   	    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � DataContext 5      .  (Chat_WpfAppt.MVM.ViewModel.MainViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      .+�5   
   �� -   5        $��2��5      ���#252525._�5      � $��Stretch=�6   .+�5      �� $��DeanChat��6   
�������$��SemiBold"�6=   �� 5       $��Right=�6    �� Orientation$ 
Horizontal=�69   .+�5!      �� -   5        $��20��5!      $��20��5"      $��_��5#      
������ $��0q�5%      
�������$
��Bold"�5'      $��0,0,0,3q�5(      5)      �� 5+      -   5        $��20��5+      $��20��5,      $	��□��5-      
������ $��0q�5/      
�������$
��Bold"�51      52      �� 54      -   5        $��20��54      $��20��55      $��X��56      
������ $��0q�58      
�������$
��Bold"�5:      5;      5=      5>      5@      � 5B   
   ���#2F3136$��1��6$    5C      �� 5D      $��50 �6    �� 5E      �� 5F      $��60 �6    .+�5I      �� $��Contacts��6   $��Center=�5J      $��Medium"�5K      
�������$��8,0,0,0q�5M      �� 5P      
������ $��0q�5S      $��1��5T         ContactCard#��[  5U      ��5P      �� *
Contacts+ �� SelectedItem 5Q      �� *SelectedContact+5U      �� 5X      $��2��6   $ 
Horizontal=�5Y      ���#292B2f.+�5[      ��  �� CornerRadius$ 25��6   $��30��5\      $��30��5]      ���#3bff6f$��18,0,0,0q�5_      �� 5`      $��Center=�6   .+�5a      �� $��Username��6   
�������$��SemiBold"�5c      $��	0,-5,0,-5q�5d      �� 5e      $��Custom Status��6   
�������$��SemiBold"�5g      $��10(�5h      $��	0,-8,0,-5q�5i      5k      5m      5n      � 5q   
   $��1��6   $��1��5r       5s      �� 5t      $��50 �6    �� 5u      �� 5v      $��70 �6    .+�5z      �� ���#2f3136$��0,0,0,2q�5{      ._�5|      � $��Stretch=�6   $��8q�5}      .+�5~      �� $��	@Username��6   
�������$
��Bold"�5�      $��5,0,5,0q�5�      $��Center=�5�      �� 5�      $ 
Horizontal=�6!   $��Right=�5�   !   .+�5�      �� $��20��6    $��20��5�       	 �� BitmapScalingMode$
	 Fant=�5�       $��5,0,5,0q�5�       $��./Icons/Phone.ico��5�       �� 5�      $��20��6    $��20��5�       $
	 Fant=�5�       $��5,0,5,0q�5�       $��./Icons/Camera1.ico��5�       5�      5�      5�      �� 5�      
������ $��0q�5�        ChatItem#��[ 5�      $��8,0,0,0q�5�      $��1��5�      ��5�      �� *SelectedContact.Messages+5�      � 5�      $��2��6    5�      �� 5�      �� 5�      $��90 �6'   .+�5�      �� $��1��6   $��50��5�      $��Message @Username��5�        
MessageBox#��[ 5�      $��2��5�      �� 5�      $ 
Horizontal=�6   $��Right=�5�      $��1��5�      $��0,0,16,0q�5�      .+�5�      �� $��./Icons/Plus.ico��6   $��20��5�      $��20��5�      $
	 Fant=�5�      $��5,5,5,0q�5�      �� 5�      $��./Icons/Send.ico��6   $��20��5�      $��20��5�      $
	 Fant=�5�      $��5,5,16,0q�5�      5�      5�      5�      5�      5�      