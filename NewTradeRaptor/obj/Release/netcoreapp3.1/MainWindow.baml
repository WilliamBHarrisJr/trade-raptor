   M S B A M L   `   `   `  ���� I  ENewTradeRaptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NewTradeRaptorNewTradeRaptor      NewTradeRaptor.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:NewTradeRaptor     -   
�������  � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ 	CanResize=� � WindowState$ 	Maximized=� � Title$ Trade Raptor��$
��1080��$
��1920��.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ dgWatchList��   RowHeaderWidth$ 0Q�$��66,311,1536,59q�$
��Bold"� � 	Resources    CenterGridHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property	 �� Value��%1   &	        �� "  .���  � ��$	 Center=�
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Symbol��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    
FontWeight$ Normal"�   FontSize$ 14Q�   HeaderStyle# [  1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Symbol+ �� Mode$ OneWay=�  $ 	Ask Price��$ * $ Normal"�$ 14Q�# [   �� *
AskPrice+$ OneWay=�  $ Ask Size��$ * $ Normal"�$ 14Q�# [   �� *	AskSize+$ OneWay=�  -   $ dgTradeList��$ 0Q�$��455,311,998,59q�$
��Bold"� ��%1   &	        �� "  .���  � ��$	 Center=�
   $ Symbol��$ * $ Normal"�$ 14Q�# [   �� *Symbol+$ OneWay=�  $ 	Ask Price��$ * $ Normal"�$ 14Q�# [   �� *
AskPrice+$ OneWay=�  $ Ask Size��$ * $ Normal"�$ 14Q�# [   �� *	AskSize+$ OneWay=�  $ 
Ask Shares��$ * $ Normal"�$ 14Q�# [   �� *TotalSalesAtCurrentAskPrice+$ OneWay=�  -   $ 	dgAccount��$ 0Q�$��987,311,64,700q�$
��Bold"�$��12(� ��%1   &	        �� "  .���  � ��$	 Center=�
   $ Account��$ * $ Regular"�$ 14Q�# [   �� *
AccountNum+$ OneWay=�  $
 Type��$ * $ Regular"�$ 14Q�# [   �� *AccountType+$ OneWay=�  $ Balance��$ * $ Regular"�$ 14Q�# [   �� *	Balance+$ OneWay=�  $ BP��$ * $ Regular"�$ 14Q�# [   �� *BP+$ OneWay=�  $	 P/L��$ * $ Regular"�$ 14Q�# [   �� *PL+$ OneWay=�  $ Commissions��$ * $ Regular"�$ 14Q�# [   �� *Commissions+$ OneWay=�  $	 ECN��$ * $ Regular"�$ 14Q�# [   �� *ECN+$ OneWay=�  -   $ dgPositions��$ 0Q�$��987,415,64,552q�$
��Bold"� ��%1   &	        �� "  .���  � ��$	 Center=�
   $ Symbol��$ * $ Regular"�$ 14Q�# [   �� *Symbol+$ OneWay=�  $ Shares��$ * $ Regular"�$ 14Q�# [   �� *Shares+$ OneWay=�  $ 	Avg Price��$ * $ Regular"�$ 14Q�# [   �� *
AvgPrice+$ OneWay=�  -   $ dgOrders��$ 0Q�$��990,564,62,403q�$
��Bold"� ��%1   &	        �� "  .���  � ��$	 Center=�
   $
 Side��$ * $ Regular"�$ 14Q�# [   �� *Side+$ OneWay=�  $ Symbol��$ * $ Regular"�$ 14Q�# [   �� *Symbol+$ OneWay=�  $ Price��$ * $ Regular"�$ 14Q�# [   �� *Price+$ OneWay=�  $ Shares��$ * $ Regular"�$ 14Q�# [   �� *Shares+$ OneWay=�  -   $ 
dgTradeLog��$ 0Q�$��990,718,62,59q�$
��Bold"� ��%1   &	        �� "  .���  � ��$	 Center=�
   $
 Side��$ * $ Regular"�$ 14Q�# [   �� *Side+$ OneWay=�  $ Symbol��$ * $ Regular"�$ 14Q�# [   �� *Symbol+$ OneWay=�  $ Price��$ * $ Regular"�$ 14Q�# [   �� *Price+$ OneWay=�  $ Shares��$ * $ Regular"�$ 14Q�# [   �� *Shares+$ OneWay=�  $
 Time��$ * $ Regular"�$ 14Q�# [   �� *Time+$ OneWay=��� $��
Watch List��$
��Left=�$��191,283,0,0q�$	��Top=�$
��Bold"��� $��
Trade List��$
��Left=�$��657,283,0,0q�$	��Top=�$
��Bold"��� $��Account��$
��Left=�$��1393,285,0,0q�$	��Top=�$
��Bold"��� $��Open Positions��$
��Left=�$��1372,389,0,0q�$	��Top=�$
��Bold"�$��26���� $��Orders��$
��Left=�$��1398,537,0,0q�$	��Top=�$
��Bold"�$��26���� $��	Trade Log��$
��Left=�$��1390,692,0,0q�$	��Top=�$
��Bold"�$��27���� -    ��Name$ lblWatchListCount��$��0 Items��$
��Left=�$��197,1003,0,0q�$	��Top=�$
��Bold"��� -	   $ lblTradeListCount��$��0 Items��$
��Left=�$��661,1003,0,0q�$	��Top=�$
��Bold"��� -
   $ 
lblMaxLoss��$��Max Loss Reached��$��18(�$
��bold"�
���  �� J� Opacity$ 0Q�$
��Left=�$��1342,180,0,0q�$	��Top=��� -   $ lblPowerFailed��$��Power Failed��$��18(�$
��bold"�
���  ��$ 0Q�$
��Left=�$��1685,115,0,0q�$	��Top=��� -   $ lblTradingDayEnded��$��Trading Ended At��$��18(�$��DemiBold"�
�����p�$ 0Q�$
��Left=�$��120,163,0,0q�$	��Top=�$	��264����  �� TextAlignment$ Right=�$��Right=�$��
0,42,181,0q�$
��Wrap=�$��14(�$��DAS Trader:��$	��Top=�$��98��$��22��$��DemiBold"��� $ Right=�$��Right=�$��
0,87,180,0q�$
��Wrap=�$��14(�$��Trade Raptor:��$	��Top=�$��98��$��22��$��DemiBold"��� $ Right=�$��Right=�$��
0,64,181,0q�$
��Wrap=�$��14(�$��Power Supply:��$	��Top=�$��98��$��22��$��DemiBold"��� -    ��Name$ 
tbTRStatus��$
 Left=�$��Right=�$��	0,87,62,0q�$
��Wrap=�$��14(�$	��Top=�$	��109��$��22��$
��Bold"��� -   $ tbConnectionStatus��$��Not Connected��
���  ��$
 Left=�$��Right=�$��	0,42,63,0q�$
��Wrap=�$��14(�$	��Top=�$	��109��$��22��$��DemiBold"��� -   $ tbPowerStatus��$
 Left=�$��Right=�$��	0,64,62,0q�$
��Wrap=�$��14(�$	��Top=�$	��109��$��22��$
��Bold"��� -   $ tbProfit��$��35(�
���"�"�$ Center=�$
��Left=�$��1308,109,0,0q�$	��Top=�$��58��$	��230���� -   $ tbClock��$��35(�
�����p�$ Center=�$
��Left=�$��122,109,0,0q�$	��Top=�$��45��$	��210���� -    ��Name$ tbAddSymbol��$��14(�$
��Left=�$��183,232,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��83��$��26���� -    ��Name$ btnStart��$��Start��${�False��
������$��14(�$��Regular"�$
��Left=�$��846,229,0,0q�$	��Top=�$��29��$��78���� -   $ btnStop��$
��Stop��${�False��
�������$��14(�$��Regular"�$
��Left=�$��983,229,0,0q�$	��Top=�$��29��$��77��o� -   $
��Menu��$��
0,0,0,1034q�.@�m� $
��File��$��14(�.@�m� -    m�Name$ menuBtnStart��$��Start Trading��${�False�� m� Icon �� $+��%C:\Users\wbhar\Pictures\StartMenu.png��m� -   $ menuBtnStop��$��Stop Trading��${�False�� �� $*��$C:\Users\wbhar\Pictures\StopMenu.png��m� -   $ menuBtnClose��$��Close�� �� $+��%C:\Users\wbhar\Pictures\CloseMenu.png��m� -   $ menuBtnSettings��$��Settings��$��14(�.@�m� -   $ 
TRSettings��$��Trade Settings�� �� $.��(C:\Users\wbhar\Pictures\SettingsIcon.png��m� -   $ DasSettings��$��DAS Settings�� �� $%��C:\Users\wbhar\Pictures\das.png��m� -   $ 
TISessings��$��TI Settings�� �� $4��.C:\Users\wbhar\Pictures\TradeIdeasMenuLogo.png��m� $��About��$��14(�.@�m� -   $ About��$��About Trade Raptor�� �� $0��*C:\Users\wbhar\Pictures\RaptorMenuIcon.png���� -   $ btnTradeIdeas��$ 0Q�${�False��$
��Left=�$��138,232,0,0q�$	��Top=�$��26��$��31���� $,��&C:\Users\wbhar\Pictures\RaptorLogo.png��$��Center=�$	��120��$	��120��$��0,64,0,0q�$	��Top=�