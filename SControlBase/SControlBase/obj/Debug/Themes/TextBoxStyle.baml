   M S B A M L   `   `   `  ����G  CSControlBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SControlBaseSControlBase  5      A%clr-namespace:SControlBase.ConvertersSControlBase.Converters  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source>    8SControlBase.Converters.TextFieldHintVisibilityConverter $   TextFieldHintVisibilityConverter 
 Freeze  	TextBrush �� Color  MaterialDesignTextBox �� 
TargetType �� Property �� Value �� RelativeSource �� AncestorType �� Path-  'System.Windows.Input.KeyboardNavigation ) %MaterialDesignValidationErrorTemplate	 m� Command
 m� Icon  MaterialDesignBody �� 
TargetType ��Name J� SnapsToDevicePixels �� Padding ��Name � UseLayoutRounding   SControlBase.SmartHint  Name   Hint   	HintProxy6   0SControlBase.Converters.HintProxyFabricConverter   Instance �� 	Converter   HintOpacity   UseFloating   FloatingScale   FloatingOffset   SControlBase.CustomLine  Name �� Triggers ]� 
Conditions �� 
SourceName �� Property �� Value  �� 
TargetName   SControlBase.HintAssist! P� Property" P� Value % !MaterialDesignFloatingHintTextBox# �� BasedOn�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      HopAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/options  5      "wpfclr-namespace:SControlBase  5      4
converters%clr-namespace:SControlBase.Converters  5        5      �� 5   
   $" ValidationErrorTemplate.xaml?�6   �� 5	   
   $ SmartHintStyle.xaml?�6   %�  &	        &	      &	 G     7  &	 J    7     5      62   �� 5      4True 68   $ #673ab7��6(   6K   �� 5      " ��6*   .�5   
   ��  � �� 6'   ��  �� " �$ (TextElement.Foreground)��� 5   
    � ��# �  6(   �� 5   
    � ��$ 0 0 0 1q�6,   �� 5   
    � ��
 ���� 6'   �� 5   
    �@��
CaretBrush 6'   ��  �� *Self+$ BorderBrush��� 5   
    �@ TabNavigation$
 None=�6=   �� 5   
    � ��$ Stretch=�67   �� 5   
    � ��$ Bottom=�65   �� 5   
    �@�FocusVisualStyle 6-   Z� �� 5   
    �@J�	AllowDrop . 6&   �� 5   
    �@��PanningMode$ VerticalFirst=�65   �� 5   
    �@��IsFlicksEnabled .  63   �� 5   
    �@=�ErrorTemplate8   65   �� 5   
    �@�ContextMenu 5      �� 5       .@�5!      m� $
��_Cut��6   $		 Cut��6-   
 5"      (� 5#      $��16��6&   $��16��61   .��5$   "   �� $��24��6)   $��24��64   .+�5%   &   F� �������!��- �@]� @T� ���� �ا р�O 	= р�O��- � �  �� ��y�  � � �  � � � �y� � �  � � ��  � � �  � � �  �� � �  � Ѐ�[  -1� 	= ����� �� � 	= ����J  $� ��[  $� � z ����� �� � z p�#`Vl  -1��[  -1Ѐ�[  z � 	= ��[ ��� �� � 	= ��J ��J  	= ��[  	= � z ��[ ��� �� � z p}l `Vl  z ��[  z �@� ��t Ӱ�� ��l ��� 0�d ��� ��[ ׀�[ ��   	=  	= ׀� ��[   	=  	= ׀�[ ���   	=  	= �0�d ��� ��l ��� ��t @� р��  � ���t �� Ӡ�l P�� 0�d ��� ��[ ��� ׀� ��  	=  	= ׀�[ ��O  	=  	= ׀�� ��  	=  	= Ӏ�� Ч	��� `C@� @�� � � ��� ���!@o@р�O@o@р�O -1�@� ��t 	#���  62  5&   #   5'      5)      m� 5*      $��_Copy��6   $
	 Copy��6.   
 5+      (� 5,      $��16��6&   $��16��61   .��5-   "   �� $��24��6)   $��24��64   .+�5.   &   F� �������!@o@� z @o@� z ��j ���!��j ���!@KL � z @KL ׀�[ ��j  �� �� р�[ @o@� z ��^ �� �� ���!��^�@o@@o@ �� �� �@o@��j ���!@KL  �� �� � $� @B � 	= @B ׀� ��-  �� �� р� @f� 	= @f� 	= ��- � $� ��- � $� @B 	#���  6�   5/   #   50      52      m� 53      $��_Paste��6   $	 Paste��6/   
 54      (� 55      $��16��6&   $��16��61   .��56   "   �� $��24��6)   $��24��64   .+�57   &   F� �������! -1�@KL  -1�@KL  	= ���j  	= ���j ��j �@f��j �@f 	= ���! 	= � � �� �@]� ��- �� �  	= ���ا ��- �� � �� ����!�� Ѡ"� �� � �� @�  ��  � ��D�      |� @� `� �� �@KL �� ���-  	=  �� �� ���-  -1�@KL ��O �� �� ���!��O�@o@ -1 �� �� �@o@ 	= ���!��  �� �� 	#���  6	  58   #   59      5;      5<      5>      �� 5?   
    � �� 5@      �� 5A      " ��6"   .R�5B      � .+�5C      �� $ border��6!   #��z��5D   !   #��z��5E   !   #��z��5F   !    . $ 0 4 0 4q�5H   !   ._�5I      � #��z��6#   #��z��5J   #   #��z��5K   #   .+�5L   "   �� $ PART_ContentHost��6/   |�.  $��Hidden=�5M   /   $��Hidden=�6V   # z 5N   /   # z 5O   /     5Q   "   $
 Hint��60   #��z��5T   0   #��z��5U   0    5R   0   �� $ (wpf:HintAssist.Hint)� �� *TemplatedParent+ 5S   0   ��  �� *TemplatedParent+# Z  5V   0   �� $" (wpf:HintAssist.HintOpacity)� �� *TemplatedParent+ 5W   0   �� $! (wpf:HintAssist.IsFloating)� �� *TemplatedParent+ 5X   0   �� $$ (wpf:HintAssist.FloatingScale)� �� *TemplatedParent+ 5Y   0   �� $% (wpf:HintAssist.FloatingOffset)� �� *TemplatedParent+5[      5\        5]      $ 	Underline��6)   y�6<   �� $0 *(wpf:TextFieldAssist.DecorationVisibility)� �� *TemplatedParent+5^       5_      ]� 5`       5a      �� 5b   "   $
 Hint��6,    �@ IsContentNullOrEmpty .  6^   �� 5c   "    �@J�IsKeyboardFocused . 6I   ./�5e      �� $
  Hint��6%    � �� �#673ab76M   �� 5f      $
  Hint��6%    �@ HintOpacity$ 1Q�6N   5g      P� 5h      ! �@ 
IsFloating" . . �5i      �� $  border��6%    � ��$ 0 18 0 0q�6K   5j      P� 5k      ! � {�" .  . �5l      �� $  border��68    �@J�Opacity$
 0.56Q�6L   5m      P� 5n      ! �@J�IsMouseOver" . . �5o      ��  � �� �#673ab76<   5p      P� 5q      ! �@J�IsKeyboardFocused" . . �5r      �� $  	Underline��6%    �@ IsActive . 6P   5s      P� 5t      ! �@=�HasError" . . �5u      ��  � �� �#f443366<   �� 5v      $  	Underline��6%    � �� �#f443366R   5w      5y      5{      5|      �� 5}      " ��66   8#   .�5~   
   ��  �@ 
IsFloating . 66   5      5�      