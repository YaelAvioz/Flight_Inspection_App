   M S B A M L   `   `   `  ����G  Ccombination1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:combination1.controlscombination1.controls  5      !    combination1.controls.Graph   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  6E   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      /local#clr-namespace:combination1.controls  5      $	��450��5      $	��470��6,   .��5      � $��0,0,-195.667,-35q�6   .+�5	   
   �� -   5        $
��Left=�5	   Y   $	��Top=�6t   $	��120��6�   $��	49,34,0,0q�6�     OxyPlot.Wpf.PlotView  5
   
   $��8,184,510,150q�61       Model  6   �� *	MyModel+61     5   
   $��158,184,357.667,150q�68     6   �� *CorelatedModel+68     5   
   $��312,132,212.667,202q�62   $��Center=�6O    J� RenderTransformOrigin$ 	0.5,0.367&�6q     6   �� *
RegModel+z�5      V� 5      .~�5      �� �� 5      �� 5      T� 5       T� Y$ 52.577Q�6)   5      5      �� 5   
   -   5        $��
dllTextBox��5   �   $
��Left=�6   $��23��6-   $��
216,33,0,0q�69    �� TextWrapping$
 Wrap=�6M   
�������$��2,2,2,2q�6x   
���   �$��Enter dll path��6�   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $��	dllButton��5   �   $
��Load��6   $
��Left=�6    $��
265,73,0,0q�6;   $	��Top=�6O   $��75��6g   $��2,2,2,2q�6r   
���   �6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dllDataGrid��5   r   $
��Left=�6   $��79��6.   $��
19,100,0,0q�6:   $	��Top=�6N   $	��442��6f    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
 ����63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0,0,1,2q�68   �� 5       � ��
 �   �64   5      5          Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 time��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *time+6L     5#      $	 feature1��6%   $
 * 6U    68   �� *
feature1+6U     5$      $	 feature2��6%   $
 * 6T    67   �� *
feature2+6T   5&      �� 5'   
   -   5        $��algoTextBox��5'   �   $
��Left=�6   $��21��6-   $��	50,74,0,0q�69   $
 Wrap=�6L   $��no dll was upload��6`   $	��Top=�6y   $��2,2,2,2q�6�   
���   �$	��123��6�   
���  ��6�   5(      5)      