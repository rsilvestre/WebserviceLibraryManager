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
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:WebsIFAC/DemandeAnnulationIFAC", ConfigurationName="WCF.Proxies.DemandeAnnulationIFAC")]
    public interface DemandeAnnulationIFAC
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/DemandeAnnulationIFAC/DemandeAnnulationIFAC/SelectById", ReplyAction="urn:WebsIFAC/DemandeAnnulationIFAC/DemandeAnnulationIFAC/SelectByIdResponse")]
        System.Collections.Generic.List<WebsBO.DemandeAnnulationBO> SelectById(string Token, int pDemandeAnnulationId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/DemandeAnnulationIFAC/DemandeAnnulationIFAC/SelectById", ReplyAction="urn:WebsIFAC/DemandeAnnulationIFAC/DemandeAnnulationIFAC/SelectByIdResponse")]
        System.IAsyncResult BeginSelectById(string Token, int pDemandeAnnulationId, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.DemandeAnnulationBO> EndSelectById(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/DemandeAnnulationIFAC/DemandeAnnulationIFAC/InsertDemandeAnnulationB" +
            "yAdmininistrateur", ReplyAction="urn:WebsIFAC/DemandeAnnulationIFAC/DemandeAnnulationIFAC/InsertDemandeAnnulationB" +
            "yAdmininistrateurResponse")]
        WebsBO.DemandeAnnulationBO InsertDemandeAnnulationByAdmininistrateur(string token, int pAdministrateurId, int pDemandeReservationId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/DemandeAnnulationIFAC/DemandeAnnulationIFAC/InsertDemandeAnnulationB" +
            "yAdmininistrateur", ReplyAction="urn:WebsIFAC/DemandeAnnulationIFAC/DemandeAnnulationIFAC/InsertDemandeAnnulationB" +
            "yAdmininistrateurResponse")]
        System.IAsyncResult BeginInsertDemandeAnnulationByAdmininistrateur(string token, int pAdministrateurId, int pDemandeReservationId, System.AsyncCallback callback, object asyncState);
        
        WebsBO.DemandeAnnulationBO EndInsertDemandeAnnulationByAdmininistrateur(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/DemandeAnnulationIFAC/DemandeAnnulationIFAC/InsertDemandeAnnulationB" +
            "yClient", ReplyAction="urn:WebsIFAC/DemandeAnnulationIFAC/DemandeAnnulationIFAC/InsertDemandeAnnulationB" +
            "yClientResponse")]
        WebsBO.DemandeAnnulationBO InsertDemandeAnnulationByClient(string token, int pClientId, int pDemandeReservationId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/DemandeAnnulationIFAC/DemandeAnnulationIFAC/InsertDemandeAnnulationB" +
            "yClient", ReplyAction="urn:WebsIFAC/DemandeAnnulationIFAC/DemandeAnnulationIFAC/InsertDemandeAnnulationB" +
            "yClientResponse")]
        System.IAsyncResult BeginInsertDemandeAnnulationByClient(string token, int pClientId, int pDemandeReservationId, System.AsyncCallback callback, object asyncState);
        
        WebsBO.DemandeAnnulationBO EndInsertDemandeAnnulationByClient(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DemandeAnnulationIFACChannel : WCF.Proxies.DemandeAnnulationIFAC, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DemandeAnnulationIFACClient : System.ServiceModel.ClientBase<WCF.Proxies.DemandeAnnulationIFAC>, WCF.Proxies.DemandeAnnulationIFAC
    {
        
        public DemandeAnnulationIFACClient()
        {
        }
        
        public DemandeAnnulationIFACClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public DemandeAnnulationIFACClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public DemandeAnnulationIFACClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public DemandeAnnulationIFACClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Collections.Generic.List<WebsBO.DemandeAnnulationBO> SelectById(string Token, int pDemandeAnnulationId)
        {
            return base.Channel.SelectById(Token, pDemandeAnnulationId);
        }
        
        public System.IAsyncResult BeginSelectById(string Token, int pDemandeAnnulationId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectById(Token, pDemandeAnnulationId, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.DemandeAnnulationBO> EndSelectById(System.IAsyncResult result)
        {
            return base.Channel.EndSelectById(result);
        }
        
        public WebsBO.DemandeAnnulationBO InsertDemandeAnnulationByAdmininistrateur(string token, int pAdministrateurId, int pDemandeReservationId)
        {
            return base.Channel.InsertDemandeAnnulationByAdmininistrateur(token, pAdministrateurId, pDemandeReservationId);
        }
        
        public System.IAsyncResult BeginInsertDemandeAnnulationByAdmininistrateur(string token, int pAdministrateurId, int pDemandeReservationId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginInsertDemandeAnnulationByAdmininistrateur(token, pAdministrateurId, pDemandeReservationId, callback, asyncState);
        }
        
        public WebsBO.DemandeAnnulationBO EndInsertDemandeAnnulationByAdmininistrateur(System.IAsyncResult result)
        {
            return base.Channel.EndInsertDemandeAnnulationByAdmininistrateur(result);
        }
        
        public WebsBO.DemandeAnnulationBO InsertDemandeAnnulationByClient(string token, int pClientId, int pDemandeReservationId)
        {
            return base.Channel.InsertDemandeAnnulationByClient(token, pClientId, pDemandeReservationId);
        }
        
        public System.IAsyncResult BeginInsertDemandeAnnulationByClient(string token, int pClientId, int pDemandeReservationId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginInsertDemandeAnnulationByClient(token, pClientId, pDemandeReservationId, callback, asyncState);
        }
        
        public WebsBO.DemandeAnnulationBO EndInsertDemandeAnnulationByClient(System.IAsyncResult result)
        {
            return base.Channel.EndInsertDemandeAnnulationByClient(result);
        }
    }
}
