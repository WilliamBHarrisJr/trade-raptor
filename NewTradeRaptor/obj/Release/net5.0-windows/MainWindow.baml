   M S B A M L   `   `   `  ���� I  ENewTradeRaptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NewTradeRaptorNewTradeRaptor      NewTradeRaptor.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:NewTradeRaptor     -   
�������  � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ CanMinimize=� � WindowState$ Normal=� � Title$ Trade Raptor��$
��1039��$
��1300��.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ dgWatchList��   RowHeaderWidth$ 0Q�$��75,307,915,63q�$
��Bold"� � 	Resources    CenterGridHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property	 �� Value��%1   &	        �� "  .���  � ��$	 Center=�
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Symbol��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    
FontWeight$ Normal"�   FontSize$ 14Q�   HeaderStyle# [  1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Symbol+ �� Mode$ OneWay=�  $ 	Ask Price��$ * $ Normal"�$ 14Q�# [   �� *
AskPrice+$ OneWay=�  $ Ask Size��$ * $ Normal"�$ 14Q�# [   �� *	AskSize+$ OneWay=�  -   $ 	dgAccount��$ 0Q�$��494,307,72,647q�$
��Bold"�$��12(� ��%1   &	        �� "  .���  � ��$	 Center=�
   $ Account��$ * $ Regular"�$ 14Q�# [   �� *
AccountNum+$ OneWay=�  $ Equity��$ * $ Regular"�$ 14Q�# [   �� *Equity+$ OneWay=�  $ BP��$ * $ Regular"�$ 14Q�# [   �� *BP+$ OneWay=�  $	 P/L��$ * $ Regular"�$ 14Q�# [   �� *PL+$ OneWay=�  -   $ dgPositions��$ 0Q�$��494,411,72,464q�$
��Bold"� ��%1   &	        �� "  .���  � ��$	 Center=�
   $ Symbol��$ * $ Regular"�$ 14Q�# [   �� *Symbol+$ OneWay=�  $ Shares��$ * $ Regular"�$ 14Q�# [   �� *Shares+$ OneWay=�  $
 Type��$ * $ Regular"�$ 14Q�# [   �� *PositionType+$ OneWay=�  $ Realized��$ * $ Regular"�$ 14Q�# [   �� *
Realized+$ OneWay=�  $ 	Avg Price��$ * $ Regular"�$ 14Q�# [   �� *
AvgPrice+$ OneWay=�  -   $ dgOrders��$ 0Q�$��497,588,72,320q�$
��Bold"� ��%1   &	        �� "  .���  � ��$	 Center=�
   $
 Side��$ * $ Regular"�$ 14Q�# [   �� *Side+$ OneWay=�  $ Symbol��$ * $ Regular"�$ 14Q�# [   �� *Symbol+$ OneWay=�  $ Price��$ * $ Regular"�$ 14Q�# [   �� *Price+$ OneWay=�  $ Shares��$ * $ Regular"�$ 14Q�# [   �� *Shares+$ OneWay=�  -   $ 
dgTradeLog��$ 0Q�$��495,736,72,60q�$
��Bold"� ��%1   &	        �� "  .���  � ��$	 Center=�
   $
 Side��$ * $ Regular"�$ 14Q�# [   �� *Side+$ OneWay=�  $ Symbol��$ * $ Regular"�$ 14Q�# [   �� *Symbol+$ OneWay=�  $ Price��$ * $ Regular"�$ 14Q�# [   �� *Price+$ OneWay=�  $ Shares��$ * $ Regular"�$ 14Q�# [   �� *Shares+$ OneWay=�  $
 Time��$ * $ Regular"�$ 14Q�# [   �� *Time+$ OneWay=��� $��
Watch List��$
��Left=�$��196,279,0,0q�$	��Top=�$
��Bold"��� $��Account��$
��Left=�$��833,281,0,0q�$	��Top=�$
��Bold"��� $��	Positions��$
��Left=�$��831,385,0,0q�$	��Top=�$
��Bold"�$��26���� $��Orders��$
��Left=�$��837,562,0,0q�$	��Top=�$
��Bold"�$��26�� J� RenderTransformOrigin$ -1.003,0.598&��� $��	Trade Log��$
��Left=�$��829,708,0,0q�$	��Top=�$
��Bold"�$��28���� -    ��Name$ lblWatchListCount��$��0 Items��$
��Left=�$��200,942,0,0q�$	��Top=�$
��Bold"��� -   $ 
lblMaxLoss��$��Max Loss Reached��$��18(�$
��bold"�
���  �� J� Opacity$ 0Q�$
��Left=�$��1042,150,0,0q�$	��Top=�$��31���� -	   $ lblPowerFailed��$��Power Failed��$��18(�$
��bold"�
���  ��$ 0Q�$
��Left=�$��1074,186,0,0q�$	��Top=�$ 0.5,0.5&�$	��134��$��29���� -
   $ lblTradingDayEnded��$��Trading Ended At��$��18(�$��DemiBold"�
�����p�$ 0Q�$
��Left=�$��130,146,0,0q�$	��Top=�$	��264��$��35����  �� TextAlignment$ Right=�$��Right=�$��
0,40,155,0q�$
��Wrap=�$��14(�$��DAS Trader:��$	��Top=�$��98��$��22��$��DemiBold"��� $ Right=�$��Right=�$��
0,88,153,0q�$
��Wrap=�$��14(�$��Trade Raptor:��$	��Top=�$��98��$��22��$��DemiBold"��� $ Right=�$��Right=�$��
0,63,155,0q�$
��Wrap=�$��14(�$��Power Supply:��$	��Top=�$��98��$��21��$��DemiBold"��� -    ��Name$ 
tbTRStatus��$
 Left=�$��Right=�$��	0,88,35,0q�$
��Wrap=�$��14(�$	��Top=�$	��110��$��22��$
��Bold"��� -   $ tbConnectionStatus��$��Not Connected��
���  ��$
 Left=�$��Right=�$��	0,40,37,0q�$
��Wrap=�$��14(�$	��Top=�$	��108��$��22��$��DemiBold"��� -   $ tbPowerStatus��$
 Left=�$��Right=�$��	0,63,35,0q�$
��Wrap=�$��14(�$	��Top=�$	��110��$��21��$
��Bold"��� -   $ tbProfit��$��$234.65��$��30(�
���"�"�$ Center=�$
��Left=�$��1047,110,0,0q�$	��Top=�$��35��$	��150���� -   $ tbClock��$��30(�
�����p�$ Center=�$
��Left=�$��130,106,0,0q�$	��Top=�$��35��$	��210���� -    ��Name$ tbAddSymbol��$��14(�$
��Left=�$��188,212,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��84��$��26���� -    ��Name$ btnStart��$��Start��${�False��
������$��14(�$��Regular"�$
��Left=�$��542,215,0,0q�$	��Top=�$��30��$��78���� -   $ btnStop��$
��Stop��${�False��
�������$��14(�$��Regular"�$
��Left=�$��662,215,0,0q�$	��Top=�$��30��$��78��o� -   $
��Menu��$
��1300��$��	0,0,0,978q�.@�m� $
��File��$��14(�.@�m� -    m�Name$ menuBtnStart��$��Start Trading��${�False�� m� Icon �� $+��%C:\Users\wbhar\Pictures\StartMenu.png��m� -   $ menuBtnStop��$��Stop Trading��${�False�� �� $*��$C:\Users\wbhar\Pictures\StopMenu.png��m� -   $ menuBtnClose��$��Close�� �� $+��%C:\Users\wbhar\Pictures\CloseMenu.png��m� -   $ menuBtnSettings��$��Settings��$��14(�.@�m� -   $ 
TRSettings��$��Trade Settings�� �� $.��(C:\Users\wbhar\Pictures\SettingsIcon.png��m� -   $ DasSettings��$��DAS Settings�� �� $%��C:\Users\wbhar\Pictures\das.png��m� -   $ 
TISessings��$��TI Settings�� �� $4��.C:\Users\wbhar\Pictures\TradeIdeasMenuLogo.png��m� $��About��$��14(�.@�m� -   $ About��$��About Trade Raptor�� �� $0��*C:\Users\wbhar\Pictures\RaptorMenuIcon.png���� $,��&C:\Users\wbhar\Pictures\RaptorLogo.png��$
��Left=�$	��120��$	��120��$��
581,40,0,0q�$	��Top=��� -   $ btnTI��$
{�True��$	 100Q�$��14(�$
��Left=�$��142,210,0,0q�$	��Top=�$��30��$��30��.���� $6��0C:\Users\wbhar\Pictures\TradeIdeasButtonLogo.png��