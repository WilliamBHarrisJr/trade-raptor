   M S B A M L   `   `   `  ����I  ENewTradeRaptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NewTradeRaptorNewTradeRaptor  5   	   &     NewTradeRaptor.DasSettingsWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:NewTradeRaptor     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   
������� � Title$ DAS Trader Settings��5   	   $	��700��6%   $	��600��62   .��5      �  � RowDefinitions 5   
   �� 5      $
��100* �6   �� 5      $	��71* �6   .+�5   
   �� -   5         ��Name$ btnSave��5      $
��Save��69   $��14(�6H   $��DemiBold"�6V   $
��Left=�6l   $��170,185,0,0q�6�   $	��Top=�6�   $��34��6�   $��79��6�   $��1��6�   �� 5   
   -   5        $ 	btnCancel��5      $��Cancel��6=   $��14(�6N   $��DemiBold"�6\   $
��Left=�6r   $��344,185,0,0q�6�   $	��Top=�6�   $��34��6�   $��78��6�   $��1��6�   �� 5   
   -   5         ��Name$ 
tbUserName��5      $
��Left=�6&   $��14(�6A   $��269,301,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ tbPort��5      $
��Left=�6"   $��14(�6=   $��269,256,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��69��6�   G� 5   
   -   5         G�Name$ 
pbPassword��5      $
��Left=�6*   $��14(�6E   $��269,346,0,0q�6S   $	��Top=�6h   $	��120��6�   �� 5   
   $��Port:��6   $��14(�6    $��DemiBold"�6.   $
��Left=�6D   $��218,252,0,0q�6_   $	��Top=�6t    J� RenderTransformOrigin$ 0.461,2.028&�6�   $��42��6�   �� 5   
   $��	Username:��6   $��14(�6$   $��DemiBold"�62   $
��Left=�6H   $��183,297,0,0q�6c   $	��Top=�6x   �� 5   
   $��	Password:��6   $��14(�6$   $��DemiBold"�62   $
��Left=�6H   $��185,342,0,0q�6c   $	��Top=�6x   �� 5   
   -   5        $ tbMaxSymbols��5      $
��Left=�6(   $��14(�6C   $��
269,40,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $��45��6�   $��1��6�   �� 5   
   $��Max Symbols:��6   $��14(�6'   $��DemiBold"�65   $
��Left=�6K   $��
161,36,0,0q�6f   $	��Top=�6z   $ 0.461,2.028&�6�   $��99��6�   $��1��6�   �� 5   
   $)��#C:\Users\wbhar\Pictures\DasLogo.png��6   $
��Left=�6=   $	��100��6X   $��
254,28,0,0q�6e   $	��Top=�6y   $	��100��6�   �� 5   
   $��Account:��6   $��14(�6#   $��DemiBold"�61   $
��Left=�6G   $��191,387,0,0q�6b   $	��Top=�6w   $��2��6�   �� 5   
   -   5        $ 	tbAccount��5      $
��Left=�6%   $��14(�6@   $��269,391,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   $��2��6�   5!      5"      