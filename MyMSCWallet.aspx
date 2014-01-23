<%@ Page Title="Chart Simple Send" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="MyMSCWallet.aspx.vb" Inherits="MyMSCWallet" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>MyMastercoins Wallet</h2>
    <br />
    The software is in the testing stages.
    You can use it
    <ol> 
    <li>Send MSC (simple send)</li>
    <li>Send TMSC (simple send)</li>
    <li>Sell TMSC Distributed Exchange</li>
    <li>Buy TMSC Distributed Exchange</li>
    </ol>  
    <br />
    <br />
    1. <strong>Look for Bitcoin.conf and get the RPCUser and RPCPassword</strong><br />
    Click Start<br />
             In the 
    &quot;Search Program Files&quot; enter &quot;%appdata%&quot;<br />
             Double Click Bitcoin<br />
             Open bitcoin.conf with notepad<br />
             Take note of your RPCUser and RPCPassword<br />
    <br />
    2. <strong>Run
     "C:\Program Files (x86)\Bitcoin\bitcoin-qt.exe" -server</strong><br />
    Please run this in a bitcoin wallet with a few bitcoins ex. 0.01 btc.&nbsp;&nbsp; 
    <br />
    <br />
    3. <strong>Download and Install the package</strong><br />
             <a href="https://github.com/Bitoy88/MyMasterCoinsThinClientWallet/">https://github.com/Bitoy88/MyMasterCoinsThinClientWallet/</a><br />
             Extract mymastercoinsTCW.zip<br />
             Run setup.exe<br />
             Follow the instructions to install MyMastercoins TCW (Thin Client Wallet)
    <br />
   <br />
   4. <strong>Run Wallet</strong><br />
          Click Start<br/>
             Click MyMastercoinsTCW<br/>
             <br />
             <br />
    5.  <strong>Settings</strong><br />
             <br />
             <img src="Images/MMC6.jpg" /><br />
             <br />
             Enter Your RPC Settings<br />
             Enter the RPCUser<br />
             Enter RPC Password<br />
             Click Update<br />
             Restart the MyMastercoinsTCW<br />
             <br />
             If your Bitcoin wallet is locked, enter the wallet passphrase below.&nbsp;&nbsp;&nbsp; 
             When you exit , the passphrase is not saved.&nbsp;&nbsp; You have to enter it again 
             to send coins.<br />
             <br />
             <br />
             <br />
    


             <strong>Transactions<br />
    </strong>shows you a list of all transactions for the given address.<br />
             <br />
&nbsp;<img src="Images/MMC1.jpg" /><br />
             <br />
             <br />
             <strong>Send TMSC</strong><br />
             <br />
&nbsp;<img src="Images/MMC2.jpg" /><br />
             <br />
             Enter &quot;Send to:&quot;.&nbsp; The Bitcoin address of the person you are sending TSMC<br />
             Enter &quot;TSMC to Send&quot; amount&nbsp; (ex. 1.12345678)<br />
             Click &quot;Send TSMC&quot;<br />
             <br />
             <br />
             <strong>Sell TMSC</strong><br />
             <br />
             <img src="Images/MMC3.jpg" /><br />
             <br />
             Enter TSMC to sell<br />
             Enter Total BTC Desired<br />
             Enter the Time Limit.&nbsp;
             <br />
             ex. If you enter 10 and&nbsp;the buyer purchase offer is received on block 
             2100.&nbsp; Payment must be received before block 2010.&nbsp; If not the 
             transaction is cancelled.
             <br />
             Enter Transaction Fee.&nbsp; Enter the minimum fee the buyer has to pay.<br />
             Click &quot;Sell TMSC&quot;<br />
             &quot;Your Current Sell Offer&quot; will be updated within 15 minutes (requires 1 
    confirmation from the network.)<br />
    <br />
             <br />
             <strong>Buy TMSC</strong><br />
             <br />
&nbsp;<img src="Images/MMC4.jpg" /><br />
    <br />
    Click on a row.<br />
    You can enter a smaller Purchase Amount.<br />
    Click &quot;Send Purchase Offer&quot;<br />
    Click on the Payment Tab<br />
    Wait (15 minutes) for the Purchase offer to be confirmed by the network .<br />
    <br />
    <strong>Send Payment</strong><br />
    <br />
&nbsp;<img src="Images/MMC5.jpg" />&nbsp;
             <br />
             <br />
             Click on the Row<br />
    You can change the Payment Amount<br />
             Click &quot;Send Payment&quot;<br />
            Click &quot;Transactions&quot; tab<br />
    (Wait for at least 15 minutes for the Transaction to appear)<br />
            <br />
         
    <br />
    <br />
         
</asp:Content>
