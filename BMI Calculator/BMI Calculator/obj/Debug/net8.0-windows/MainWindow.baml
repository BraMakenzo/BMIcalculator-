   M S B A M L   `   `   `  ����  BMI Calculator    BMI_Calculator.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  BMI Calculator��5   	   $	��500��6    $	��400��6-   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��BMI Calculator��6   $��24(�6*   $
��Bold"�68   $��0 0 0 20q�5      $��0��6&   $��Center=�63   �� 5   
   $��1��6    �� Orientation$ Vertical=�6"   $��0 0 0 10q�69   .+�5      �� $
��Age:��6   �� 5      -   5         ��Name$ AgeInput��5      �� 5      $��Weight (kg):��6   �� 5      -   5        $ WeightInput��5      �� 5       $��Height (m):��6   �� 5!      -   5        $ HeightInput��5!      5"      �� 5%   
   -   5        $��Calculate BMI��5%      $��2��6)   $��30��66   $��	0 10 0 10q�6B   6U   �� 5(   
   $��3��6   $��	0 10 0 10q�6"   .+�5)      �� $��Result:��6   $
��Bold"�6'   �� 5*      -   5         ��Name$ 
ResultText��5*      $��16(�6,   $��0 5 0 0q�6:   �� 5+      -   5        $ 
AdviceText��5+      
�������$
��Wrap=�6>   $��0 5 0 0q�6R   5,      �� 5/   
   $��4��6   $��0 10 0 0q�6"   .+�50      �� -   5        $��Show BMI History��50      $��0 5 0 5q�6J   51      �� 54   
   $��5��6   $
��Auto=�6$   .��55      �� -   5        $ HistoryText��55      $
��Wrap=�6-   $��12(�6A   56      57      58      