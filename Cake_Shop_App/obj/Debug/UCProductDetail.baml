   M S B A M L   `   `   `  ����H  DCake_Shop_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Cake_Shop_AppCake_Shop_App  5      #    Cake_Shop_App.UCProductDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Cake_Shop_App     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      
������   MaterialDesignFont#���  5       � 	Resources 5      "   Cake_Shop_App.PriceConverter  PriceConverter��%   &	         5   
   6   5      .��5      ]� -   5        $��
WorkScreen��5      ��. .+�5   
   �  � ColumnDefinitions 5      �� 5      $	��600 �6#   �� 5      $��* �6#   .+�5      � $��0��6    � RowDefinitions 5      �� 5      $	��400 �6$   �� 5      $��* �6$   .+�5       � $��0��6   .+�5!      ��  �� CornerRadius$ 5��6   $��	10,10,0,0q�6.   ��5"      �� 5#       �� BitmapScalingMode$ HighQuality=�6O    j� Stretch$ UniformToFill=�6}    �� ImageSource 6)   �� *ProductAvatar+6}   5%      5&      � 5(      $��1��6   $��5q�6$   .+�5)      �� -   5        	 ��Name$	 PreviewPhoto��5)   4   $��5,0,0,0q�6#   $	��590��6J   ��5*      �� 5+      .R�5,   "   �� $
��Auto=�6/   $��Disabled=�6T   .��5-   &   �� 5.   #   5/      ��51      �� 52      .R�53   "   � 
 � Orientation$
 Vertical=�6,   54      ��56      �� 57      .R�58   "   ��  � Cursor$
 Hand��6/   ��6=   �� *
listImages+��59   &   �� 5:   *   .R�5;   .   � $
 
Horizontal=�68   5<   +   ��5>   &   �� 5?   *   .R�5@   .   � .+�5A   2   �� $ 5��69   $��0q�6J   $	��150��6^   $	��150��6j   $��0,0,5,0q�6w   ��5B   6   �� 5C   :   $ UniformToFill=�6E   $ HighQuality=�6u    6]   �� 6u   5E   3   5F   /   5G   +   5I   #   5J      5L      5M      5N      � 5P      $��1��6    5Q      �� 5R      $��50 �6$   �� 5S      $��* �6$   .+�5V      � $��0��6   $��5q�6$   .+�5W      ��  �� Orientation$ 
Horizontal=�6!   $
��Left=�6:   $	��Top=�6U   .+�5X      �� $��Danh Mục /��6    $��Center=�65   $��Center=�6W   ���#555$��18(�6�   $��Center=�6�   $
��Left=�6�   �� 5Y      -   5        $��Category��5Y       $��Center=�6D   $��Center=�6f   ���#555$��18(�6�   $��Center=�6�   $
��Left=�6�   ��60   �� 6�   5Z      �� 5[      -   5        $��editProduct��5[   /   $
 Hand��6!   $ 
Horizontal=�6d   $��Right=�6}   $	��Top=�6�   .+�5\      �� $��Assets/edit.png��6    $��25��69   $��25��6E   $ HighQuality=�6P   $��Center=�6~   $��Center=�6�   �� 5]      $��CHỈNH SỬA THÔNG TIN��6    $��Center=�6>   $��Center=�6`   ���#555$��18(�6�   $��Center=�6�   $
��Left=�6�   5^      5_      � 5a      $��1��6   $��5q�6$   .+�5b      �� $
��Left=�6!   $	��Top=�6<   .+�5c      �� $��Center=�6@   $��Center=�6b   ���#555$��27(�6�   $��Center=�6�   $
��Left=�6�   $��2,0,0,0q�6�   $
��Bold"�6�   ��6    �� *ProductName+6�   �� 5d      ���#777$��5��63   $��52��6>   $
��Left=�6I   $��6,10,0,0q�6d   6x   � 5f      $��6,16,0,0q�6$   .+�5g      �� $��25(�6j   
���   �$
��Wrap=�6�   $��Center=�6�    �� TextAlignment$ Justify=�6�   $
��Bold"�6�   ��6(   �� *Price+ �� 	Converter# [ ��6�   Z� 6�   5h      �� 5j      $��Center=�6A   $��Center=�6c   ���#555$��20(�6�   $��Center=�6�   $
��Left=�6�   $��5,10,0,0q�6�   $
��Bold"�6�   ��6    �� *productTitle+6�   �� 5l      $��Hidden=�6'   $	��320��6L   .��5m      �� $
��Wrap=�6(   $��5,15,0,0q�6`   $��18(�6r   ���#555$��Center=�6�   $ Justify=�6�   ��6<   �� *ProductDescription+6�   5n      �� 5o      -   5         ��Name$ OrderButton��5o   !   $ 2��6X   $��35��6i   $	��100��6u   $
 Hand��6�   $��2q�6�   $��5,20,0,0q�6�   ���#fc5753���#fc5753$
��Left=�6�   ._�5p      �� $	��100��6$   $��2q�60   $��15(�6<   
�������$��Center=�6]   $��Center=�6x   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   ��6�   Z� ��5q   "   �� 5r   &   $��	MUA HÀNG��61   5t      5u      5v      5w      5x      5y      5z      5{      