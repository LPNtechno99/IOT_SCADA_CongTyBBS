   M S B A M L   `   `   `  ����O  KSCADA_IOT_CompanyBBS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SCADA_IOT_CompanyBBSSCADA_IOT_CompanyBBS  5   	   #    SCADA_IOT_CompanyBBS.wdChonCa   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:SCADA_IOT_CompanyBBS     5   	   -   5          � Title$  wdChonCa��5   	   $	��250��6   $	��500��6'    � WindowStartupLocation$ CenterScreen=�63    � 	Resources 5
         myCommandF1 �� Text  myCommandF2  myCommandF3  myCommandEsc  myCommandENTER��%�   &	        &	      &	 <     &	 Z     &	 x     �� 5   
   $
 text��6.   �� 5   
   $
 text��6.   �� 5   
   $
 text��6.   �� 5   
   $
 text��6/   �� 5   
   $
 text��61   5       J� InputBindings 5      �� 5   
   
 �� Key$ F1��6    �� Command# [  6   �� 5   
   $ F2��6   # [ 6   �� 5   
   $ F3��6   # [ 6   �� 5   
   $	 Esc��6   # [ 6   �� 5   
   $ Return��6   # [ 6"    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6@     5   
   -   5        # [ 5      6@     5   
   -   5        # [ 5      6@     5   
   -   5        # [ 5      6A     5   
   -   5        # [ 5      6C   .��5      � ���	#FF5FB5F1	 � RowDefinitions	 5    
   �� 5!      �� 5"      $��35 �6   .+�5$   
   �� 
�������$��1q�6%   ._�5%      � 
 � ColumnDefinitions
 5&      �� 5'      $	��120 �6'   �� 5(      �� 5)      �� 5*      	 5,      �� 5-      �� 5.      �� 5/      �� 50      .+�52      �� $��0��6   $��0��6(     LabelTemplate#��[ 65   ���	#FF2546B8$��CA HIỆN TẠI��53   /   
�������$��16(�6X   �� 54      -   5        $��lblCa1��55   Q   $��0��54      $��1��6(   #��[ 65   ���	#FF2546B8$
��CA 1��55   /   
�������6Q   �� 56      -   5        $��lblCa2��57   Q   $��0��56      $��2��6(   #��[ 65   ���	#FF2546B8$
��CA 2��57   /   
�������6Q   �� 58      -	   5        $��lblCa3��59   Q   $��0��58      $��3��6(   #��[ 65   ���	#FF2546B8$
��CA 3��59   /   
�������6Q   �� 5;      $��1��6   $��0��6(     LabelTemplateNormal#��[ 65   ���	#FF2546B8$
��Từ��5<   /   
�������6<   �� 5=      $��2��6   $��0��6(   #��[ 65   ���	#FF2546B8$��Đến��5>   /   
�������6=   �� 5@      -
   5        $��lblFrom1��5A   Z   $��1��5@      $��1��6(   #��[ 65   
�������
���   �$	��...��5A   >   $��20(�6L   6Z   �� 5B      -   5        $��lblFrom2��5C   Z   $��1��5B      $��2��6(   #��[ 65   
�������
���   �$	��...��5C   >   $��20(�6L   6Z   �� 5D      -   5        $��lblFrom3��5E   Z   $��1��5D      $��3��6(   #��[ 65   
�������
���   �$	��...��5E   >   $��20(�6L   6Z   �� 5F      -   5        $��lblTo1��5G   Z   $��2��5F      $��1��6(   #��[ 65   
�������
���   �$	��...��5G   >   $��20(�6L   6Z   �� 5H      -   5        $��lblTo2��5I   Z   $��2��5H      $��2��6(   #��[ 65   
�������
���   �$	��...��5I   >   $��20(�6L   6Z   �� 5J      -   5        $��lblTo3��5K   Z   $��2��5J      $��3��6(   #��[ 65   
�������
���   �$	��...��5K   >   $��20(�6L   6Z   �� 5M      $��3��6   $��0��6(   #��[ 65   ���	#FF2546B8$��Tổng��5N   /   
�������6>   �� 5O      -   5        $��lblTongThoiGianCa1��5P   Z   $��3��5O      $��1��6(   #��[ 65   
�������
���   �$	��...��5P   >   $��20(�6L   6Z   �� 5Q      -   5        $��lblTongThoiGianCa2��5R   Z   $��3��5Q      $��2��6(   #��[ 65   
�������
���   �$	��...��5R   >   $��20(�6L   6Z   �� 5S      -   5        $��lblTongThoiGianCa3��5T   Z   $��3��5S      $��3��6(   #��[ 65   
�������
���   �$	��...��5T   >   $��20(�6L   6Z   5U      5V      �� 5W   
   $��2��6   ._�5X      �� #��[ 6   $#��Ấn ENTER để tiếp tục��6>   
�������$��18(�5Y   '   ���	#FF84B96565   5Z      5[      5\      