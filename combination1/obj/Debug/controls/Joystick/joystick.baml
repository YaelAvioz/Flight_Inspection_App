   M S B A M L   `   `   `  ����G  Ccombination1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:combination1.controlscombination1.controls  5      $    combination1.controls.joystick   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:combination1.controls     5      $��673.134��5      $��950.355��60   .��5	      �   � ColumnDefinitions  5
   
   �� 5      $
��317* �6   �� 5      $
��427* �6    � RowDefinitions 5   
   �� 5      $
��366* �6   �� 5      $	��38* �6   �� 5      $
��245* �6   .+�5   
   �� -   5         ��Name$
 Base��5      $��307,64,405.6,115.6q�6    $��2��6<   .+�5      A� $��Center=�6   $	��140��63   $��Center=�6@   $	��140��6[   $��90,40,350,140q�6g   ��5      
� 5      .��5      �  � Color$ 	#FF2C2A2A��6'    � Offset$ 1Q�69   � 5      $ 	#FF3A3737��6'   5      5      A� 5      $
��Left=�6   $��80��61   $	��Top=�6=   $��80��6U    �� Left$ 84��6`   
 �� Top$ 84��6q   $��35,-15,350,140q�6�   ��5      
� 5      .��5       � $ 	#FF0E0E0E��6'   $ 1Q�69   � 5!      $ 	#FF1D1D1D��6'   � 5"      $ 	#FF323030��6'   $ 0.453Q�69   5#      5%      F� 5&      "�����~C�[��xօP��� ���[�	���	#FF575757$
��Left=�6Y   $��18.375��6t    �� Stretch$
 Fill=�6�    � UseLayoutRounding .  $	��Top=�6�   $��42.75��6�   $	 135��6�   $ 45��6�   F� 5'      "�����~C�[��xօP��� ���[�	���	#FF575757$
��Left=�6Y   $��18.375��6t   $
 Fill=�6�    .  $	��Top=�6�   $��42.75��6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   $	 135��6�   $	 160��6  z�5(      �� 5)      
 �� ScaleY$
 -1Q�6%   5+      F� 5,      "�����~C�[��xօP��� ���[�	���	#FF575757$
��Left=�6Y   $��18.375��6t   $
 Fill=�6�    .  $	��Top=�6�   $��42.75��6�   $	 0.5,0.5&�6�   $	 195��6�   $	 100��6  z�5-      V� 5.      .~�5/      �� $
 -1Q�6)    �� ScaleX$ -1Q�65   �� 50       �� Angle$	 -90Q�6*   51      53      F� 54      "�����~C�[��xօP��� ���[�	���	#FF575757$
��Left=�6Z   $��18.375��6u   $
 Fill=�6�    .  $	��Top=�6�   $��42.75��6�   $	 0.5,0.5&�6�   $ 80��6�   $	 100��6  z�55      V� 56      .~�57      �� $ 90Q�6*   �� 58      $ -1Q�6)   59      5;      �� 5=      -   5        $
 Knob��5=      $	��Top=�6$   $
��Left=�6<   $��41��6W   $��19��6b   $	 0.5,0.5&�6n    6�   �� *VM_ElipseLeft+ �� Mode$ OneWay=� 6�   �� *VM_ElipseTop+$ OneWay=�.+�5>      A� -   5         A�Name$ KnobBase��5>      $
��Left=�6,   $��30��6G   $	��Top=�6S   $��30��6k   $	 0.5,0.5&�6v   $ 11��6�   ��5?      
� 5@      .��5A      � $ 	#FF8A8A8A��6+   � 5B      $ 	#FF979797��6+   $ 1Q�6=   5C      5E      z�5G      V� 5H      .~�5I      �� $
 -1Q�6)   $ -1Q�65   �� 5J      �� 5K      T� 5L      5M       � 	Resources 5O       g�Name   
CenterKnob��%.   &	        �� 5Q      $ 
centerKnob��64   5R      5S      5T      �� 5U   
   $��38��6   $��399,46,428.6,281.6q�6    $
��Wrap=�6<   $��← aileron →��6P   $��center=�6c    �� TextAlignment$ Center=�6~   $��20(�6�   $��Century Gothic)�6�   $��UltraExpanded&�6�   $��	UltraBold"�6�   $��2��6�   �� 5W   
   $
��Wrap=�6   $��← elevator →��6(   $ Center=�6<   $��20(�6S   $��Century Gothic)�6b   $��UltraExpanded&�6~   $��	UltraBold"�6�   $��102,98,357,142q�6�   $��1��6�   z�5X      V� 5Y      .~�5Z      �� �� 5[       �� AngleX$	 0.6Q�6$   �� 5\      T� 5]       T� X$ -0.454Q�6)   5^       � LayoutTransform 5`      �� 5a      $ 90Q�6"   5c      �� 5e   
   $
��Wrap=�6   $��← throttle →��6(   $ Center=�6<   $��20(�6S   $��Century Gothic)�6b   $��UltraExpanded&�6~   $��	UltraBold"�6�   $��239,109,74,142q�6�    5g      �� 5h      $ 90Q�6"   5j      �� 5l   
   $
��Left=�6   $��40��6/   $��
399,0,0,51q�6;   $
��Wrap=�6O   $��← rudder →��6c   $��Bottom=�6u   $	��122��5m      $ Center=�6   $��20(�65   $��Century Gothic)�6D   $��UltraExpanded&�6`   $��	UltraBold"�6|   $��2��6�   �� 5o   
   $
��Left=�6   $	��160��62   $��
340,87,0,0q�6?   $	��Top=�6S   $��21��6k   $	 0.5,0.5&�6v   z�5p      V� 5q      .~�5r      �� �� 5s      �� 5t      $ 0.319Q�6&   T� 5u      5v      5x      �� 5y   
   $
��Left=�6   $��20��62   $��368,264,0,0q�6>   $	��Top=�6S   $	��180��6k   $��2��6w   �� 5{   
   -   5        $
 Rect��5{      $	��Top=�6    $
��Left=�68   $��0��6S   $��0��6]   $	 0.5,0.5&�6h   .+�5|      �� $
��Left=�6   $��20��63   $	��Top=�6?   $��22��6W   $	 0.5,0.5&�6b   $��1��6�   $	 340��6�    6�   �� *VM_Rect1Top+$ OneWay=�z�5}      V� 5~      .~�5      �� $ -1Q�6)   �� 5�      �� 5�      T� 5�      5�      ��5�      
� 5�      .��5�      � $ 	#FF2C2A2A��6'   $ 1Q�69   � 5�      $ 	#FF3A3737��6'   5�      5�      z�5�      T� 5�      -   5        RectPosition��5�   %    5�        
CenterRect �� 
TargetName �� TargetProperty	 W� To g� Duration W� EasingFunction-  'System.Windows.Media.Animation.BackEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode��%U  &	       �� 5�      $ 
centerRect��60   .��5�      W� $ RectPosition��6&   $ X�5�      $ 0X�6<   $ 0:0:0.2D�6C    5�        5�      $ 	EaseInOut=�6'   5�      W� 5�      $ Rectosition��6&   $ Y�6J   $ 0X�6h   $ 0:0:0.2D�6o    5�        5�      $ 	EaseInOut=�6'   5�      5�      5�      5�      �� 5�   
   -   5        $ RectR��5�      $	��Top=�6!   $
��Left=�69   $��0��6T   $��0��6^   $	 0.5,0.5&�6i   .+�5�      �� $
��Left=�6   $��20��63   $	��Top=�6?   $��20��6W   $	 3.575,12.188&�6b   $	 264��6�    6�   �� *VM_Rect2Left+$ OneWay=���5�      
� 5�      .��5�      � $ 	#FF2C2A2A��6'   $ 1Q�69   � 5�      $ 	#FF3A3737��6'   5�      5�      z�5�      T� 5�      -   5        RectRPosition��5�   %    5�      ��%Y  &	        �� 5�      $ centerRectR��60   .��5�      W� $ RectRPosition��6&   $ X�5�      $ 0X�6<   $ 0:0:0.2D�6C    5�        5�      $ 	EaseInOut=�6'   5�      W� 5�      $ RectRPosition��6&   $ Y�6L   $ 0X�6j   $ 0:0:0.2D�6q    5�        5�      $ 	EaseInOut=�6'   5�      5�      5�      5�      5�      5�      