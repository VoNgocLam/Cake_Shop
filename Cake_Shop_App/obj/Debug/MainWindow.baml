   M S B A M L   `   `   `  ����H  DCake_Shop_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Cake_Shop_AppCake_Shop_App  5   	       Cake_Shop_App.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Cake_Shop_App     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ 
MainWindow��5   	   $	��800��63   $
��1400��6@    � UseLayoutRounding .   �� BitmapScalingMode$ HighQuality=�6g    � WindowStartupLocation$ CenterScreen=�6�   .��5      ]� -   5        $��
mainWindow��5      ��. .+�5   
   � -   5        $��TopGrid��5      $	��Top=�6   $��50��63   $	��Top=�6?   ���#dfdddf.+�5      �� -   5        $��TopLabel��5      $��Center=�6$   $��Paradise Cake��6A   $��50��6Y   $��20(�6e   $��Center=�6s   ���#6767676�   � 5      $
��Left=�6   $��Center=�63   .+�5      �� -   5        $��
ExitButton��5       & "MaterialDesignFloatingActionButton#��[ 6E   $y�Visible=�6�   $��15��6�   $��15��6�   ���#fc605c$��10,0,0,0q�6�   ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6.   $��10��6;   $��10��6F   ���#7e05096R   5      �� 5      -   5        $��MinimizeButton��5      #��[ 6M   $y�Visible=�6�   $��15��6�   $��15��6�   ���#fec041$��10,0,0,0q�6�   ��6�   Z� .��5        $ WindowMinimize=�6.   $��10��6D   $��10��6O   ���#9857126[   5       5"      �� 5$      -   5        	 ��Name$	 
CartButton��5$      $��30��6J   $��30��6U   $��Right=�6a   $��0,0,20,0q�6}   
������ $��0q�6�   $ HighQuality=�6�   ��5%      �� 5&      
 �� ImageSource$
 Assets/shopping-cart.png��6!   $ HighQuality=�6H   5(      5+      � 5-   
   -   5        $
��Home��5-      ���#ececec.+�5.      �� $
��1350��6   $	��680��6"   ���#e3e3e3$��0,20,0,0q�6D    �� CornerRadius$ 10��6V   ._�5/      ]� .+�50      �� $	��900��6   $��40��6)   $	��Top=�65   ���#ffff$	��Top=�6]   $��	0,-20,0,0q�6u   $ 5��6�   ._�51      ��  �� Orientation$ 
Horizontal=�6%   .+�52      �� -	   5        $��ProductButton��52   %   $	��300��6V   $��40��6b   $��Sản phẩm��6n   $��Bahnschrift Light)�6�   $��16(�6�   
���   �
������ ���#e5e5e5$	��0.2q�6�   �� 53      -
   5        $��CreateButton��53   %   $	��300��6T   $��40��6`   $��Thêm mới sản phẩm��6l   $��Bahnschrift Light)�6�   $��16(�6�   
���   �
������ ���#e5e5e5$	��0.2q�6�   �� 54      -   5        $��StatisticalButton��54   %   $	��300��6^   $��40��6j   $��Thống kê��6v   $��Bahnschrift Light)�6�   $��16(�6�   
���   �
������ ���#e5e5e5$	��0.2q�6�   55      56      �� 58      $
��Left=�6   $
��1290��68   $	��600��6E   
�������$ 10��6e   $��30,0,0,0q�6w   ._�59      ]� ��. .+�5:      � -   5        $��
WorkScreen��5:   #   5<      5=      5>      5?      5@      5A      5C      5D      