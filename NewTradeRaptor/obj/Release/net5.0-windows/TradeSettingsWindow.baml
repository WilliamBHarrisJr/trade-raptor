   M S B A M L   `   `   `  ���� I  ENewTradeRaptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NewTradeRaptorNewTradeRaptor  (    "NewTradeRaptor.TradeSettingsWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:NewTradeRaptor       � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ NoResize=�
������� � Title$ Trade Settings��$	��700��$	��600��.��� .+��� -    ��Name$ btnSave��$
��Save��$��14(�$��DemiBold"�$
��Left=�$��170,585,0,0q�$	��Top=�$��34��$��79���� -   $ 	btnCancel��$��Cancel��$��14(�$��DemiBold"�$
��Left=�$��344,585,0,0q�$	��Top=�$��34��$��78���� -    ��Name$ tbProfitTargetA��$��14(�$
��Left=�$��405,459,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��58��$��23���� -   $ tbMaxShareSize��$��14(�$
��Left=�$��200,193,0,0q�$
 Wrap=�$	��Top=�$��50��$��23���� -   $ tbProfitTargetB��$��14(�$
��Left=�$��405,502,0,0q�$
 Wrap=�$	��Top=�$��58��$��23���� -   $ tbMinShareSize��$��14(�$
��Left=�$��199,235,0,0q�$
 Wrap=�$	��Top=�$��50��$��23���� -   $ 	tbMaxLoss��$��14(�$
��Left=�$��420,355,0,0q�$
 Wrap=�$	��Top=�$��49��$��23���� $��Min Share Size:��$��14(�$��DemiBold"�$
��Left=�$��
86,229,0,0q�$	��Top=�$	��106���� $��Max Share Size:��$��14(�$��DemiBold"�$
��Left=�$��
87,188,0,0q�$	��Top=�$	��108���� $��	Max Loss:��$��14(�$��DemiBold"�$
��Left=�$��343,350,0,0q�$	��Top=�$��72���� -    ��Name$ cbAllOrHalf��$��14(�$
��Left=�$��168,459,0,0q�$	��Top=�$��70������ *SellAllOrHalf+�� $��Sell:��$��14(�$��DemiBold"�$
��Left=�$��123,458,0,0q�$	��Top=�$��36���� -	   $ cbSellAt��$��14(�$
��Left=�$��282,459,0,0q�$	��Top=�$	��106������ *
PTReversal+�� $	��At:��$��14(�$��DemiBold"�$
��Left=�$��248,457,0,0q�$	��Top=�$��29���� -
   $ cbSellRestAt��$��14(�$
��Left=�$��282,503,0,0q�$	��Top=�$	��106������ *
PTReversal+�� -    ��Name$ lblSellRestAt��$"��Sell:      The Rest      At:��$��14(�$��DemiBold"�$
��Left=�$��122,502,0,0q�$	��Top=�$	��155���� -   $ tbBuyTrigger��$��14(�$
��Left=�$��200,314,0,0q�$
 Wrap=�$	��Top=�$��50��$��22���� $��Buy Trigger:��$��14(�$��DemiBold"�$
��Left=�$��109,309,0,0q�$	��Top=�$��86���� -   $ 
tbStopTime��$��14(�$
��Left=�$��420,235,0,0q�$
 Wrap=�$	��Top=�$��77��$��23���� $��
Stop Time:��$��14(�$��DemiBold"�$
��Left=�$��337,229,0,0q�$	��Top=�$��78���� 
�����p�$��1q�$��51,409,32,115q��� $��Sell Triggers��
�����p�$��14(�$��DemiBold"�$
��Left=�$��263,414,0,0q�$	��Top=�$	��120���� $0��*C:\Users\wbhar\Pictures\RaptorSettings.png��$
��Left=�$	��110��$��
247,28,0,0q�$	��Top=�$	��113���� -   $ tbStartTime��$��14(�$
��Left=�$��420,194,0,0q�$
 Wrap=�$	��Top=�$��77��$��23���� $��Start Time:��$��14(�$��DemiBold"�$
��Left=�$��337,188,0,0q�$	��Top=�$��78���� -   $ tbLowTrigger��$��14(�$
��Left=�$��200,275,0,0q�$
 Wrap=�$	��Top=�$��50��$��23���� $��Low Trigger:��$��14(�$��DemiBold"�$
��Left=�$��108,271,0,0q�$	��Top=�$��92���� -   $ tbBailTrigger��$��14(�$
��Left=�$��201,352,0,0q�$
 Wrap=�$	��Top=�$��49��$��23���� $��Bail Trigger:��$��14(�$��DemiBold"�$
��Left=�$��109,347,0,0q�$	��Top=�$��87���� -    ��Name$ cbBail��$�� ��$
��Left=�$��269,356,0,0q�$	��Top=��� -   $ 
tbBailTime��$��14(�$
��Left=�$��420,316,0,0q�$
 Wrap=�$	��Top=�$��77��$��23���� $��
Bail Time:��$��14(�$��DemiBold"�$
��Left=�$��337,310,0,0q�$	��Top=�$��78���� -   $ tbBreakEvenTime��$��14(�$
��Left=�$��420,275,0,0q�$
 Wrap=�$	��Top=�$��77��$��23���� $��Break Even Time:��$��14(�$��DemiBold"�$
��Left=�$��296,269,0,0q�$	��Top=�$	��119��