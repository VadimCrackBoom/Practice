   M S B A M L   `   `   `  ����?  ;todo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:todotodo  5   	       
todo.LogIn   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:todo     5   	     � Title$  LogIn��5   	   $	��600��6   $	��800��6$    � WindowStartupLocation$ CenterScreen=�60    � 
ResizeMode$ CanResizeWithGrip=�6U   $	��800��6t   $	��600��6�   .��5	      � $	��600��6   $	��800��6   .+�5
   
   �� $	��150��6   $��51,42,593,0q�6   $	��Top=�62   $��	/logo.png��6J   � 5   
   $��430,80,70,124q�6   .+�5      �� $&�� Добро пожаловать!��6   $
��Left=�60   $	��Top=�6K   $	��300��6c   $��50��6o   $��30(�6{   $��0,0,0,60q�6�   $8��2pack://application:,,,/todo;component/Fonts/#Actor)�6�   �� 5      $��
Почта��6   $��20(�6$   $��43��62   $	��201��6>   $8��2pack://application:,,,/todo;component/Fonts/#Actor)�6J   �� 5      -   5         ��Name$ emailTB��5       �� TextWrapping$
 Wrap=�6'   $	��Top=�6;   $	��300��6S   $��18��6_   $��Введите почту��6k   $��0,0,0,1q�6�   
 � Tag$ Введите почту��6�   $��14(�6�   $��0,0,0,10q�6�    J� Opacity$	 0.4Q�6�   .��6  ��5      �� 5       �� Color# � ��6&   .��5   '   5      �� 5      $��Пароль��6   $��20(�6%   $��38��63   $	��179��6?   $��0,0,0,10q�6K   $8��2pack://application:,,,/todo;component/Fonts/#Actor)�6]   �� 5      -   5        $ 
passwordTB��5      $
 Wrap=�6*   $��Center=�6>   $	��300��6Y   $��18��6e   $!��Введите пароль��6q   $��0,0,0,1q�6�   $! Введите пароль��6�   $��14(�6�   $��0,0,0,10q�6�   $	 0.4Q�6   .��6  ��5      �� 5      # � ��6&   .��5   '   5      �� 5      $+��%Восстановить пароль��6   $��20(�62   $��43��6@   $	��204��6L   $��Right=�6X   $��Center=�6t   $��80,0,0,0q�6�   $8��2pack://application:,,,/todo;component/Fonts/#Actor)�6�   �� 5      -   5        ���	#FFF96060���	#FFF96060
�������$��
Войти��5   W   $	��300��6g   $��40��6s   $��16(�6   $��0,0,0,5q�6�   $8��2pack://application:,,,/todo;component/Fonts/#Actor)�6�    � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%i   '��       �� 5      "	 ��6   .�5      �� 
 �@��CornerRadius$ 20, 20, 5, 5��69   5      5      5       �� 5!      -   5        ���	#FFF96060���	#FFF96060
�������$��Регистрация��5!   W   $	��300��6m   $��40��6y   $��16(�6�   $8��2pack://application:,,,/todo;component/Fonts/#Actor)�6�    5"      ��%i   '��       �� 5#      "	 ��6   .�5$      �� 
 �@��CornerRadius$ 5, 5, 20, 20��69   5%      5&      5'      5(      5*      5+      