   M S B A M L   `   `   `  ����H  DCake_Shop_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Cake_Shop_AppCake_Shop_App  5           Cake_Shop_App.UCNewProduct   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Cake_Shop_App     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      
������   MaterialDesignFont#���  5      .��5      ]� -   5         ]�Name$ 
WorkScreen��5      ��. .+�5   
   � $	��Top=�6   $��50��6$   $	��Top=�60   .+�5      �� $��THÊM MỚI SẢN PHẨM��6   $��	10,10,0,0q�60   $��20(�6C   $��Center=�6Q   $
��Left=�6s   ���#8d908d6�   � 5      $��Right=�6   .+�5      �� -   5        $��imgSave��5      $��Assets/save.png��6E   $��25��6^   $��25��6i    �� BitmapScalingMode$ HighQuality=�6u   $��UniformToFill=�6�   $��	0,10,15,0q�6�   �� 5      -   5         ��Name$ 	imgCancel��5      $��Assets/cancel.png��6K   $��30��6f   $��30��6q   $ HighQuality=�6}   $��UniformToFill=�6�   $��	0,10,15,0q�6�   5      5      � 5   
    � ColumnDefinitions 5      �� 5      �� 5       � RowDefinitions 5       �� 5!      $��65 �6    �� 5"      $��65 �6    �� 5#      $	��300 �6    �� 5$      .+�5&      � $��0��6   $��0��6    $��
10,10,10,5q�60   .+�5'      �� -   5         ��Name$ tbName��5'      $��20(�6*   $��0q�68   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên sản phẩm��6L   	   
IsFloating	 . .  (MaterialDesignThemes.Wpf.TextFieldAssist
   HasClearButton
 .    HasOutlinedTextField .    TextFieldCornerRadius$ 2��6     DecorationVisibility$ 	Collapsed=�6O  5(      � 5*      $��0��6   $��1��6    $��
10,10,10,5q�60   .+�5+      �� -   5        $ tbPrice��5+      $��20(�6+   $��0q�69   $ Giá (VNĐ)��6M   	 . 
 .  . $ 2��6  $ 	Collapsed=�6M  5,      � 5.      $��1��6   $��0��6    $��
10,10,10,5q�60   .+�5/      �� -   5        $ tbTitle��5/      $��20(�6+   $��0q�69   $ Tiêu đề��6M   	 . 
 .  . $ 2��6  $ 	Collapsed=�6K  50      � 52      $��1��6   $��1��6    $��
10,10,10,5q�60   .+�53      �� -   5        $ 
tbCategory��53      $��0q�6n   $��20(�6�   $	��470��6�   $
��Left=�6�   $ 
Danh mục��6�   	 . 
 .  . $ 2��6~  $ 	Collapsed=�6�  {�6.   ��  �� ElementName$ 
cbCategory�� �� Path$ SelectedItem�6�  ]� 55      $��Right=�6   .+�56      ��  �� Orientation$ 
Horizontal=�6!   .+�57      �� -	   5        $��
cbCategory��57   #   $��Center=�6d   $	��140��6�   $��54��6�   $��Center=�6�   $��Center=�6�   $��50��6�    6�   �� *CategoryName+��58      �� 59   "   .R�5:   &   �� $��15(�6N   ��60   �� *CategoryName+6N   5;   #   5=      5>      5?      5@      � 5B      $��2��6   $��3��6    $��0��61   $��10,10,10,10q�6A   .+�5C      �� -
   5        $ tbDescription��5C      $��20(�61    �� TextWrapping$
 Wrap=�6?   $��0q�6S    �� AcceptsReturn . $ Mô tả��6|   	 . 
 .  . $ 2��6?  $ 	Collapsed=�6x  5D      � 5H      $��1��6   $��2��6#   $��3��60   $��
10,10,10,5q�6A    5I      �� 5J      $��* �6$   �� 5K      $��50 �6$   .+�5N      � $��0��6   .+�5O      �� $��1q�6   ���#000 �� CornerRadius$ 1��6D   ._�5P      �� -   5         ��Name$ lvlistImages��5P   #   $	��580��69   $	��319��6E   $��Hidden=�6|   $��Disabled=�6�   ��6R   �� $ 
listImages���5Q      �� 5R   "   .R�5S   &   � 5T   $   ��5V      �� 5W   "   .R�5X   &   �� .+�5Y   *   �� $	��150��61   $	��120��6>   $��1q�6J   ��5Z   .   �� 5[   2   $ HighQuality=�6U    j� Stretch$ UniformToFill=�6�    �� ImageSource 6=   �� 6�   5]   +   5^   '   5_   #   5a      5b      5c      � 5e      $��1��6   .+�5f      �� -   5         ��Name$ ListImagesButton��5f      $��50��6�   $��70��6�   $��0,0,0,0q�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��Bottom=�6  ��6V   Z� ��6l   Z� .��5g      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ImageAdd=�62   $
��Auto��6B   $
��Auto��6O   ���#7e05086]   5h      5i      5j      5k      5m      5n      