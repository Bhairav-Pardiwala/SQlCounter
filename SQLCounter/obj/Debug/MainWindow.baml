   M S B A M L   `   `   `  ����E  ASQLCounter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SQLCounter
SQLCounter  5   	       SQLCounter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SQLCounter     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ listRecords��5   #   $��0��6   ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��10,0,0,0q�6%   $��20(�67   ��6E   �� *id+�� 5      $��10,0,0,0q�6%   $��20(�67   ��6E   �� *stamp+5      5      5      �� 5   
   $��1��6   .+�5   
   �� -   5         ��Name$ btnRead��5   ,   $��10q�6   $
��Read��6   6=   �� 5   
   -   5        $ 	btnDelete��5   .   $��10q�6   $��Delete��6   6A   �� 5      -   5        $ 	btnExport��5   2   $��10q�6   $��Export��6!   6E   �� 5      -   5         ��Name$ 
chkRefresh��5   5   $��10q�6   $��Refresh��6#   6f   �� 5      -   5         ��Name$	 cnt��5   2   $��10q�6   $��20(�6$   62   5      5       5!      