   M S B A M L   `   `   `  ���� I  ENewTradeRaptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NewTradeRaptorNewTradeRaptor  (    "NewTradeRaptor.TradeSettingsWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:NewTradeRaptor       � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ NoResize=�
������� � Title$ Trade Settings��$	��700��$	��600��.��� .+��� -    ��Name$ btnSave��$
��Save��$��14(�$��DemiBold"�$
��Left=�$��170,585,0,0q�$	��Top=�$��34��$��79���� -   $ 	btnCancel��$��Cancel��$��14(�$��DemiBold"�$
��Left=�$��344,585,0,0q�$	��Top=�$��34��$��78���� -    ��Name$ tbProfitTargetA��$��14(�$
��Left=�$��405,459,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��58��$��23���� -   $ tbMaxShareSize��$��14(�$
��Left=�$��195,191,0,0q�$
 Wrap=�$	��Top=�$��58��$��23���� -   $ tbProfitTargetB��$��14(�$
��Left=�$��405,502,0,0q�$
 Wrap=�$	��Top=�$��58��$��23���� -   $ tbMinShareSize��$��14(�$
��Left=�$��194,225,0,0q�$
 Wrap=�$	��Top=�$��58��$��23���� -   $ tbMoreBidSales��$��14(�$
��Left=�$��441,346,0,0q�$
 Wrap=�$	��Top=�$��58��$��22���� -   $ tbMoreBidShares��$��14(�$
��Left=�$��441,312,0,0q�$
 Wrap=�$	��Top=�$��58��$��22���� -	   $ 	tbMaxLoss��$��14(�$
��Left=�$��441,191,0,0q�$
 Wrap=�$	��Top=�$��68��$��23���� $��Min Share Size:��$��14(�$��DemiBold"�$
��Left=�$��
66,221,0,0q�$	��Top=�$	��106���� $��Max Share Size:��$��14(�$��DemiBold"�$
��Left=�$��
67,188,0,0q�$	��Top=�$	��108���� $��	Max Loss:��$��14(�$��DemiBold"�$
��Left=�$��352,188,0,0q�$	��Top=�$��72���� -
    ��Name$ cbAllOrHalf��$��14(�$
��Left=�$��168,459,0,0q�$	��Top=�$��70������ *SellAllOrHalf+�� $��Sell:��$��14(�$��DemiBold"�$
��Left=�$��123,458,0,0q�$	��Top=�$��36���� -   $ cbSellAt��$��14(�$
��Left=�$��282,459,0,0q�$	��Top=�$	��106������ *
PTReversal+�� $	��At:��$��14(�$��DemiBold"�$
��Left=�$��248,457,0,0q�$	��Top=�$��29���� -   $ cbSellRestAt��$��14(�$
��Left=�$��282,503,0,0q�$	��Top=�$	��106������ *
PTReversal+�� -    ��Name$ lblSellRestAt��$"��Sell:      The Rest      At:��$��14(�$��DemiBold"�$
��Left=�$��122,502,0,0q�$	��Top=�$	��155���� -    ��Name$ ckbMoreBidShares��$�� ��$
��Left=�$��513,316,0,0q�$	��Top=��� -   $ ckbMoreBidSales��$�� ��$
��Left=�$��513,350,0,0q�$	��Top=��� $��More Bid Shares:��$��14(�$��DemiBold"�$
��Left=�$��308,308,0,0q�$	��Top=�$	��116���� $��More Bid Sales:��$��14(�$��DemiBold"�$
��Left=�$��316,342,0,0q�$	��Top=�$	��108��	 J� RenderTransformOrigin$	 0.509,-0.173&��� -   $ 	cbAccount��$��14(�$
��Left=�$��202,146,0,0q�$	��Top=�$	��204������ *accountNums+�� $��Account��$��14(�$��DemiBold"�$
��Left=�$��271,116,0,0q�$	��Top=�$��82���� -   $ tbAskSizeBuy��$��14(�$
��Left=�$��191,346,0,0q�$
 Wrap=�$	��Top=�$��58��$��22���� -   $ tbAskSizeWatch��$��14(�$
��Left=�$��191,308,0,0q�$
 Wrap=�$	��Top=�$��58��$��24���� $��Ask Size Watch:��$��14(�$��DemiBold"�$
��Left=�$��
62,308,0,0q�$	��Top=�$	��116���� $��Ask Size Buy:��$��14(�$��DemiBold"�$
��Left=�$��
77,342,0,0q�$	��Top=�$	��108���� -   $ 
tbStopTime��$��14(�$
��Left=�$��441,225,0,0q�$
 Wrap=�$	��Top=�$��68��$��23���� $��
Stop Time:��$��14(�$��DemiBold"�$
��Left=�$��349,221,0,0q�$	��Top=�$��78���� 
�����p�$��1q�$��300,266,34,267q��� 
�����p�$��1q�$��53,266,300,267q��� 
�����p�$��1q�$��51,409,32,115q��� $��Reversal Triggers��
�����p�$��14(�$��DemiBold"�$
��Left=�$��366,270,0,0q�$	��Top=�$	��120��$��28���� $��Buy Triggers��
�����p�$��14(�$��DemiBold"�$
��Left=�$��121,270,0,0q�$	��Top=�$	��120��$	 0.542,-0.068&�$��32���� $��Sell Triggers��
�����p�$��14(�$��DemiBold"�$
��Left=�$��263,414,0,0q�$	��Top=�$	��120���� $0��*C:\Users\wbhar\Pictures\RaptorSettings.png��$
��Left=�$��90��$��
253,13,0,0q�$	��Top=�$��90��