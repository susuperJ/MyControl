   M S B A M L   `   `   `  ����G  CSControlBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SControlBase.TransformSControlBase.Transform  5   	   0    *SControlBase.Transform.RenderTransformDemo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:SControlBase.Transform     5   	   -   5          �Name$  WindowTransform��5   %    � Title$ RenderTransformDemo��6	   $	��300��6>   $	��300��6K    � WindowStartupLocation$ CenterScreen=�6W    � WindowStyle$
 None=�5	   	    � AllowsTransparency . 
������ $��0q�5
   "    � 	Resources 5         TransformToReverse �� 
TargetName �� TargetProperty W� From		 W� To	
 W� By g� Duration  TransformToFront��%�  &	        &	 c    �� 5   
   .��5      W� $ WindowTransform��6   $6 0(Window.RenderTransform).(ScaleTransform.ScaleX)�6F   $ -1X�5      $	 1X�6(   $
 1X�6/   $ 0:0:0.6D�66   W� 5      $ WindowTransform��6   $6 0(Window.RenderTransform).(ScaleTransform.ScaleY)�6F   $	 0.8X�5      $	 1X�6)   $
 1X�60   $ 0:0:0.7D�67   5      �� 5   
   .��5      W� $ WindowTransform��6   $6 0(Window.RenderTransform).(ScaleTransform.ScaleX)�6F   $ -1X�5      $	 1X�6(   $
 1X�6/   $ 0:0:0.6D�66   W� 5      $ WindowTransform��6   $6 0(Window.RenderTransform).(ScaleTransform.ScaleY)�6F   $	 0.8X�5      $	 1X�6)   $
 1X�60   $ 0:0:0.7D�67   5      5       J� RenderTransformOrigin$ 0.5 0.5&�5   I   z�5      �� 5   
    �� ScaleX$ 1Q�6   6&   .��5      � 
������ .+�5!   
   �� -   5         ��Name$ login��5!      $��正面��6    z�5"      �� 5#      $ 1Q�6!   6.   5%      �� 5'   
   -   5        $ SetProxy��5'      $ 0.5 0.5&�6#   $y�	Collapsed=�6C   $��反面��6Z   z�5)      �� 5*      $ 1Q�6!   6.   5,      5.      5/      