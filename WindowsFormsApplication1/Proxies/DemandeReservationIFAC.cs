﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18444
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF.Proxies
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:WebsIFAC/DemandeReservationIFAC", ConfigurationName="WCF.Proxies.DemandeReservationIFAC")]
    public interface DemandeReservationIFAC
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/SelectById", ReplyAction="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/SelectByIdResponse")]
        System.Collections.Generic.List<WebsBO.DemandeReservationBO> SelectById(string Token, int pDemandeReservationId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/SelectById", ReplyAction="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/SelectByIdResponse")]
        System.IAsyncResult BeginSelectById(string Token, int pDemandeReservationId, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.DemandeReservationBO> EndSelectById(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/SelectNewByClient", ReplyAction="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/SelectNewByClientRespo" +
            "nse")]
        System.Collections.Generic.List<WebsBO.DemandeReservationBO> SelectNewByClient(string Token, WebsBO.ClientBO pClient);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/SelectNewByClient", ReplyAction="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/SelectNewByClientRespo" +
            "nse")]
        System.IAsyncResult BeginSelectNewByClient(string Token, WebsBO.ClientBO pClient, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.DemandeReservationBO> EndSelectNewByClient(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/SelectOldByClient", ReplyAction="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/SelectOldByClientRespo" +
            "nse")]
        System.Collections.Generic.List<WebsBO.DemandeReservationBO> SelectOldByClient(string Token, WebsBO.ClientBO pClient);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/SelectOldByClient", ReplyAction="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/SelectOldByClientRespo" +
            "nse")]
        System.IAsyncResult BeginSelectOldByClient(string Token, WebsBO.ClientBO pClient, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.DemandeReservationBO> EndSelectOldByClient(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/InsertDemandeReservati" +
            "on", ReplyAction="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/InsertDemandeReservati" +
            "onResponse")]
        WebsBO.DemandeReservationBO InsertDemandeReservation(string Token, WebsBO.DemandeReservationBO pDemandeReservation);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/InsertDemandeReservati" +
            "on", ReplyAction="urn:WebsIFAC/DemandeReservationIFAC/DemandeReservationIFAC/InsertDemandeReservati" +
            "onResponse")]
        System.IAsyncResult BeginInsertDemandeReservation(string Token, WebsBO.DemandeReservationBO pDemandeReservation, System.AsyncCallback callback, object asyncState);
        
        WebsBO.DemandeReservationBO EndInsertDemandeReservation(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DemandeReservationIFACChannel : WCF.Proxies.DemandeReservationIFAC, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DemandeReservationIFACClient : System.ServiceModel.ClientBase<WCF.Proxies.DemandeReservationIFAC>, WCF.Proxies.DemandeReservationIFAC
    {
        
        public DemandeReservationIFACClient()
        {
        }
        
        public DemandeReservationIFACClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public DemandeReservationIFACClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public DemandeReservationIFACClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public DemandeReservationIFACClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Collections.Generic.List<WebsBO.DemandeReservationBO> SelectById(string Token, int pDemandeReservationId)
        {
            return base.Channel.SelectById(Token, pDemandeReservationId);
        }
        
        public System.IAsyncResult BeginSelectById(string Token, int pDemandeReservationId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectById(Token, pDemandeReservationId, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.DemandeReservationBO> EndSelectById(System.IAsyncResult result)
        {
            return base.Channel.EndSelectById(result);
        }
        
        public System.Collections.Generic.List<WebsBO.DemandeReservationBO> SelectNewByClient(string Token, WebsBO.ClientBO pClient)
        {
            return base.Channel.SelectNewByClient(Token, pClient);
        }
        
        public System.IAsyncResult BeginSelectNewByClient(string Token, WebsBO.ClientBO pClient, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectNewByClient(Token, pClient, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.DemandeReservationBO> EndSelectNewByClient(System.IAsyncResult result)
        {
            return base.Channel.EndSelectNewByClient(result);
        }
        
        public System.Collections.Generic.List<WebsBO.DemandeReservationBO> SelectOldByClient(string Token, WebsBO.ClientBO pClient)
        {
            return base.Channel.SelectOldByClient(Token, pClient);
        }
        
        public System.IAsyncResult BeginSelectOldByClient(string Token, WebsBO.ClientBO pClient, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectOldByClient(Token, pClient, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.DemandeReservationBO> EndSelectOldByClient(System.IAsyncResult result)
        {
            return base.Channel.EndSelectOldByClient(result);
        }
        
        public WebsBO.DemandeReservationBO InsertDemandeReservation(string Token, WebsBO.DemandeReservationBO pDemandeReservation)
        {
            return base.Channel.InsertDemandeReservation(Token, pDemandeReservation);
        }
        
        public System.IAsyncResult BeginInsertDemandeReservation(string Token, WebsBO.DemandeReservationBO pDemandeReservation, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginInsertDemandeReservation(Token, pDemandeReservation, callback, asyncState);
        }
        
        public WebsBO.DemandeReservationBO EndInsertDemandeReservation(System.IAsyncResult result)
        {
            return base.Channel.EndInsertDemandeReservation(result);
        }
    }
}
