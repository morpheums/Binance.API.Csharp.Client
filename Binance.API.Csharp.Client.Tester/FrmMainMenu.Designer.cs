namespace Binance.API.Csharp.Client.Tester
{
    partial class frmMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generalEndpointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkServerTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testConnectivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marketEndpointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hrTickerPriceChangeStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aggregateTradesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klineCandlesticksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getOrderBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.symbolsOrderBookTickerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.symbolsPriceTickerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountEndpointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountTradeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentOpenOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getDepositHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getWithdrawHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testNewOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withdrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depthWebsocketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klineWebsocketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradesWebsocketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userDataWebsocketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountUpdateEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderUpdateEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeUpdateEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalEndpointsToolStripMenuItem,
            this.marketEndpointsToolStripMenuItem,
            this.accountEndpointsToolStripMenuItem,
            this.userSToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(855, 55);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generalEndpointsToolStripMenuItem
            // 
            this.generalEndpointsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkServerTimeToolStripMenuItem,
            this.testConnectivityToolStripMenuItem});
            this.generalEndpointsToolStripMenuItem.Image = global::Binance.API.Csharp.Client.Tester.Properties.Resources.if_internet_web_browser_118810;
            this.generalEndpointsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.generalEndpointsToolStripMenuItem.Name = "generalEndpointsToolStripMenuItem";
            this.generalEndpointsToolStripMenuItem.Size = new System.Drawing.Size(115, 51);
            this.generalEndpointsToolStripMenuItem.Text = "General Endpoints";
            this.generalEndpointsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // checkServerTimeToolStripMenuItem
            // 
            this.checkServerTimeToolStripMenuItem.Name = "checkServerTimeToolStripMenuItem";
            this.checkServerTimeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.checkServerTimeToolStripMenuItem.Text = "Check Server Time";
            this.checkServerTimeToolStripMenuItem.Click += new System.EventHandler(this.CheckServerTimeToolStripMenuItem_Click);
            // 
            // testConnectivityToolStripMenuItem
            // 
            this.testConnectivityToolStripMenuItem.Name = "testConnectivityToolStripMenuItem";
            this.testConnectivityToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.testConnectivityToolStripMenuItem.Text = "Test Connectivity";
            this.testConnectivityToolStripMenuItem.Click += new System.EventHandler(this.TestConnectivityToolStripMenuItem_Click);
            // 
            // marketEndpointsToolStripMenuItem
            // 
            this.marketEndpointsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hrTickerPriceChangeStatisticsToolStripMenuItem,
            this.aggregateTradesListToolStripMenuItem,
            this.klineCandlesticksToolStripMenuItem,
            this.getOrderBookToolStripMenuItem,
            this.symbolsOrderBookTickerToolStripMenuItem,
            this.symbolsPriceTickerToolStripMenuItem});
            this.marketEndpointsToolStripMenuItem.Image = global::Binance.API.Csharp.Client.Tester.Properties.Resources.if_barChart_add_84264;
            this.marketEndpointsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.marketEndpointsToolStripMenuItem.Name = "marketEndpointsToolStripMenuItem";
            this.marketEndpointsToolStripMenuItem.Size = new System.Drawing.Size(112, 51);
            this.marketEndpointsToolStripMenuItem.Text = "Market Endpoints";
            this.marketEndpointsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // hrTickerPriceChangeStatisticsToolStripMenuItem
            // 
            this.hrTickerPriceChangeStatisticsToolStripMenuItem.Name = "hrTickerPriceChangeStatisticsToolStripMenuItem";
            this.hrTickerPriceChangeStatisticsToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.hrTickerPriceChangeStatisticsToolStripMenuItem.Text = "24hr Ticker Price Change Statistics";
            this.hrTickerPriceChangeStatisticsToolStripMenuItem.Click += new System.EventHandler(this.TickerPriceChangeStatisticsToolStripMenuItem_Click);
            // 
            // aggregateTradesListToolStripMenuItem
            // 
            this.aggregateTradesListToolStripMenuItem.Name = "aggregateTradesListToolStripMenuItem";
            this.aggregateTradesListToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.aggregateTradesListToolStripMenuItem.Text = "Compressed/Aggregate Trades List";
            this.aggregateTradesListToolStripMenuItem.Click += new System.EventHandler(this.aggregateTradesListToolStripMenuItem_Click);
            // 
            // klineCandlesticksToolStripMenuItem
            // 
            this.klineCandlesticksToolStripMenuItem.Name = "klineCandlesticksToolStripMenuItem";
            this.klineCandlesticksToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.klineCandlesticksToolStripMenuItem.Text = "Kline/Candlesticks";
            // 
            // getOrderBookToolStripMenuItem
            // 
            this.getOrderBookToolStripMenuItem.Name = "getOrderBookToolStripMenuItem";
            this.getOrderBookToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.getOrderBookToolStripMenuItem.Text = "Order Book";
            // 
            // symbolsOrderBookTickerToolStripMenuItem
            // 
            this.symbolsOrderBookTickerToolStripMenuItem.Name = "symbolsOrderBookTickerToolStripMenuItem";
            this.symbolsOrderBookTickerToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.symbolsOrderBookTickerToolStripMenuItem.Text = "Symbols Order Book Ticker";
            // 
            // symbolsPriceTickerToolStripMenuItem
            // 
            this.symbolsPriceTickerToolStripMenuItem.Name = "symbolsPriceTickerToolStripMenuItem";
            this.symbolsPriceTickerToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.symbolsPriceTickerToolStripMenuItem.Text = "Symbols Price Ticker";
            // 
            // accountEndpointsToolStripMenuItem
            // 
            this.accountEndpointsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountInformationToolStripMenuItem,
            this.accountTradeListToolStripMenuItem,
            this.allOrdersToolStripMenuItem,
            this.cancelOrderToolStripMenuItem,
            this.currentOpenOrdersToolStripMenuItem,
            this.getDepositHistoryToolStripMenuItem,
            this.getWithdrawHistoryToolStripMenuItem,
            this.newOrderToolStripMenuItem,
            this.queryOrderToolStripMenuItem,
            this.testNewOrderToolStripMenuItem,
            this.withdrawToolStripMenuItem});
            this.accountEndpointsToolStripMenuItem.Image = global::Binance.API.Csharp.Client.Tester.Properties.Resources.if_account_balances_63837;
            this.accountEndpointsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.accountEndpointsToolStripMenuItem.Name = "accountEndpointsToolStripMenuItem";
            this.accountEndpointsToolStripMenuItem.Size = new System.Drawing.Size(120, 51);
            this.accountEndpointsToolStripMenuItem.Text = "Account Endpoints";
            this.accountEndpointsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // accountInformationToolStripMenuItem
            // 
            this.accountInformationToolStripMenuItem.Name = "accountInformationToolStripMenuItem";
            this.accountInformationToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.accountInformationToolStripMenuItem.Text = "Account Information";
            // 
            // accountTradeListToolStripMenuItem
            // 
            this.accountTradeListToolStripMenuItem.Name = "accountTradeListToolStripMenuItem";
            this.accountTradeListToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.accountTradeListToolStripMenuItem.Text = "Account Trade List";
            // 
            // allOrdersToolStripMenuItem
            // 
            this.allOrdersToolStripMenuItem.Name = "allOrdersToolStripMenuItem";
            this.allOrdersToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.allOrdersToolStripMenuItem.Text = "All Orders ";
            // 
            // cancelOrderToolStripMenuItem
            // 
            this.cancelOrderToolStripMenuItem.Name = "cancelOrderToolStripMenuItem";
            this.cancelOrderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.cancelOrderToolStripMenuItem.Text = "Cancel Order";
            // 
            // currentOpenOrdersToolStripMenuItem
            // 
            this.currentOpenOrdersToolStripMenuItem.Name = "currentOpenOrdersToolStripMenuItem";
            this.currentOpenOrdersToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.currentOpenOrdersToolStripMenuItem.Text = "Current Open Orders";
            // 
            // getDepositHistoryToolStripMenuItem
            // 
            this.getDepositHistoryToolStripMenuItem.Name = "getDepositHistoryToolStripMenuItem";
            this.getDepositHistoryToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.getDepositHistoryToolStripMenuItem.Text = "Get Deposit History";
            // 
            // getWithdrawHistoryToolStripMenuItem
            // 
            this.getWithdrawHistoryToolStripMenuItem.Name = "getWithdrawHistoryToolStripMenuItem";
            this.getWithdrawHistoryToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.getWithdrawHistoryToolStripMenuItem.Text = "Get Withdraw History";
            // 
            // newOrderToolStripMenuItem
            // 
            this.newOrderToolStripMenuItem.Name = "newOrderToolStripMenuItem";
            this.newOrderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.newOrderToolStripMenuItem.Text = "New Order";
            // 
            // queryOrderToolStripMenuItem
            // 
            this.queryOrderToolStripMenuItem.Name = "queryOrderToolStripMenuItem";
            this.queryOrderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.queryOrderToolStripMenuItem.Text = "Query Order";
            // 
            // testNewOrderToolStripMenuItem
            // 
            this.testNewOrderToolStripMenuItem.Name = "testNewOrderToolStripMenuItem";
            this.testNewOrderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.testNewOrderToolStripMenuItem.Text = "Test New Order";
            // 
            // withdrawToolStripMenuItem
            // 
            this.withdrawToolStripMenuItem.Name = "withdrawToolStripMenuItem";
            this.withdrawToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.withdrawToolStripMenuItem.Text = "Withdraw";
            // 
            // userSToolStripMenuItem
            // 
            this.userSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.depthWebsocketToolStripMenuItem,
            this.klineWebsocketToolStripMenuItem,
            this.tradesWebsocketToolStripMenuItem,
            this.userDataWebsocketToolStripMenuItem});
            this.userSToolStripMenuItem.Image = global::Binance.API.Csharp.Client.Tester.Properties.Resources.if_arrow_refresh_35687;
            this.userSToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.userSToolStripMenuItem.Name = "userSToolStripMenuItem";
            this.userSToolStripMenuItem.Size = new System.Drawing.Size(96, 51);
            this.userSToolStripMenuItem.Text = "WebSoclet API";
            this.userSToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // depthWebsocketToolStripMenuItem
            // 
            this.depthWebsocketToolStripMenuItem.Name = "depthWebsocketToolStripMenuItem";
            this.depthWebsocketToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.depthWebsocketToolStripMenuItem.Text = "Depth Websocket ";
            // 
            // klineWebsocketToolStripMenuItem
            // 
            this.klineWebsocketToolStripMenuItem.Name = "klineWebsocketToolStripMenuItem";
            this.klineWebsocketToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.klineWebsocketToolStripMenuItem.Text = "Kline Websocket";
            // 
            // tradesWebsocketToolStripMenuItem
            // 
            this.tradesWebsocketToolStripMenuItem.Name = "tradesWebsocketToolStripMenuItem";
            this.tradesWebsocketToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.tradesWebsocketToolStripMenuItem.Text = "Trades Websocket";
            // 
            // userDataWebsocketToolStripMenuItem
            // 
            this.userDataWebsocketToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountUpdateEventToolStripMenuItem,
            this.orderUpdateEventToolStripMenuItem,
            this.tradeUpdateEventToolStripMenuItem});
            this.userDataWebsocketToolStripMenuItem.Name = "userDataWebsocketToolStripMenuItem";
            this.userDataWebsocketToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.userDataWebsocketToolStripMenuItem.Text = "User Data Websocket";
            // 
            // accountUpdateEventToolStripMenuItem
            // 
            this.accountUpdateEventToolStripMenuItem.Name = "accountUpdateEventToolStripMenuItem";
            this.accountUpdateEventToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.accountUpdateEventToolStripMenuItem.Text = "Account Update Event";
            // 
            // orderUpdateEventToolStripMenuItem
            // 
            this.orderUpdateEventToolStripMenuItem.Name = "orderUpdateEventToolStripMenuItem";
            this.orderUpdateEventToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.orderUpdateEventToolStripMenuItem.Text = "Order Update Event";
            // 
            // tradeUpdateEventToolStripMenuItem
            // 
            this.tradeUpdateEventToolStripMenuItem.Name = "tradeUpdateEventToolStripMenuItem";
            this.tradeUpdateEventToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.tradeUpdateEventToolStripMenuItem.Text = "Trade Update Event";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Image = global::Binance.API.Csharp.Client.Tester.Properties.Resources.if_config_59544;
            this.configurationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 51);
            this.configurationToolStripMenuItem.Text = "Configuration";
            this.configurationToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 556);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Binance API Csharp Tester";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generalEndpointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marketEndpointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountEndpointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testConnectivityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkServerTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getOrderBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aggregateTradesListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klineCandlesticksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hrTickerPriceChangeStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem symbolsOrderBookTickerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem symbolsPriceTickerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountTradeListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentOpenOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getDepositHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getWithdrawHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testNewOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withdrawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depthWebsocketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klineWebsocketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradesWebsocketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userDataWebsocketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountUpdateEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderUpdateEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradeUpdateEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
    }
}

