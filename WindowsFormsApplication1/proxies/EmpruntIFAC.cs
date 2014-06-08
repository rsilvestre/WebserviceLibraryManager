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
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:WebsIFAC/EmpruntIFAC", ConfigurationName="WCF.Proxies.EmpruntIFAC")]
    public interface EmpruntIFAC
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectAll", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectAllResponse")]
        System.Collections.Generic.List<WebsBO.EmpruntBO> SelectAll(string token);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectAll", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectAllResponse")]
        System.IAsyncResult BeginSelectAll(string token, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.EmpruntBO> EndSelectAll(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectEmpruntById", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectEmpruntByIdResponse")]
        WebsBO.EmpruntBO SelectEmpruntById(string token, int pId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectEmpruntById", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectEmpruntByIdResponse")]
        System.IAsyncResult BeginSelectEmpruntById(string token, int pId, System.AsyncCallback callback, object asyncState);
        
        WebsBO.EmpruntBO EndSelectEmpruntById(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectEmpruntByClientId", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectEmpruntByClientIdResponse")]
        System.Collections.Generic.List<WebsBO.EmpruntBO> SelectEmpruntByClientId(string token, int pClientId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectEmpruntByClientId", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectEmpruntByClientIdResponse")]
        System.IAsyncResult BeginSelectEmpruntByClientId(string token, int pClientId, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.EmpruntBO> EndSelectEmpruntByClientId(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/ConvertReservation", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/ConvertReservationResponse")]
        WebsBO.EmpruntBO ConvertReservation(string token, int pAdministrateurId, int pReservationId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/ConvertReservation", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/ConvertReservationResponse")]
        System.IAsyncResult BeginConvertReservation(string token, int pAdministrateurId, int pReservationId, System.AsyncCallback callback, object asyncState);
        
        WebsBO.EmpruntBO EndConvertReservation(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/InsertEmprunt", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/InsertEmpruntResponse")]
        WebsBO.EmpruntBO InsertEmprunt(string token, int pAdministrateurId, int pPersonneId, int pLivreId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/InsertEmprunt", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/InsertEmpruntResponse")]
        System.IAsyncResult BeginInsertEmprunt(string token, int pAdministrateurId, int pPersonneId, int pLivreId, System.AsyncCallback callback, object asyncState);
        
        WebsBO.EmpruntBO EndInsertEmprunt(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/InsertRetour", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/InsertRetourResponse")]
        WebsBO.EmpruntBO InsertRetour(string token, int pAdministrateurId, int pLivreId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/InsertRetour", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/InsertRetourResponse")]
        System.IAsyncResult BeginInsertRetour(string token, int pAdministrateurId, int pLivreId, System.AsyncCallback callback, object asyncState);
        
        WebsBO.EmpruntBO EndInsertRetour(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/InsertAnnul", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/InsertAnnulResponse")]
        WebsBO.EmpruntBO InsertAnnul(string token, int pAdministrateurId, int pReservationId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/InsertAnnul", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/InsertAnnulResponse")]
        System.IAsyncResult BeginInsertAnnul(string token, int pAdministrateurId, int pReservationId, System.AsyncCallback callback, object asyncState);
        
        WebsBO.EmpruntBO EndInsertAnnul(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface EmpruntIFACChannel : WCF.Proxies.EmpruntIFAC, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmpruntIFACClient : System.ServiceModel.ClientBase<WCF.Proxies.EmpruntIFAC>, WCF.Proxies.EmpruntIFAC
    {
        
        public EmpruntIFACClient()
        {
        }
        
        public EmpruntIFACClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public EmpruntIFACClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public EmpruntIFACClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public EmpruntIFACClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Collections.Generic.List<WebsBO.EmpruntBO> SelectAll(string token)
        {
            return base.Channel.SelectAll(token);
        }
        
        public System.IAsyncResult BeginSelectAll(string token, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectAll(token, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.EmpruntBO> EndSelectAll(System.IAsyncResult result)
        {
            return base.Channel.EndSelectAll(result);
        }
        
        public WebsBO.EmpruntBO SelectEmpruntById(string token, int pId)
        {
            return base.Channel.SelectEmpruntById(token, pId);
        }
        
        public System.IAsyncResult BeginSelectEmpruntById(string token, int pId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectEmpruntById(token, pId, callback, asyncState);
        }
        
        public WebsBO.EmpruntBO EndSelectEmpruntById(System.IAsyncResult result)
        {
            return base.Channel.EndSelectEmpruntById(result);
        }
        
        public System.Collections.Generic.List<WebsBO.EmpruntBO> SelectEmpruntByClientId(string token, int pClientId)
        {
            return base.Channel.SelectEmpruntByClientId(token, pClientId);
        }
        
        public System.IAsyncResult BeginSelectEmpruntByClientId(string token, int pClientId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectEmpruntByClientId(token, pClientId, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.EmpruntBO> EndSelectEmpruntByClientId(System.IAsyncResult result)
        {
            return base.Channel.EndSelectEmpruntByClientId(result);
        }
        
        public WebsBO.EmpruntBO ConvertReservation(string token, int pAdministrateurId, int pReservationId)
        {
            return base.Channel.ConvertReservation(token, pAdministrateurId, pReservationId);
        }
        
        public System.IAsyncResult BeginConvertReservation(string token, int pAdministrateurId, int pReservationId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginConvertReservation(token, pAdministrateurId, pReservationId, callback, asyncState);
        }
        
        public WebsBO.EmpruntBO EndConvertReservation(System.IAsyncResult result)
        {
            return base.Channel.EndConvertReservation(result);
        }
        
        public WebsBO.EmpruntBO InsertEmprunt(string token, int pAdministrateurId, int pPersonneId, int pLivreId)
        {
            return base.Channel.InsertEmprunt(token, pAdministrateurId, pPersonneId, pLivreId);
        }
        
        public System.IAsyncResult BeginInsertEmprunt(string token, int pAdministrateurId, int pPersonneId, int pLivreId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginInsertEmprunt(token, pAdministrateurId, pPersonneId, pLivreId, callback, asyncState);
        }
        
        public WebsBO.EmpruntBO EndInsertEmprunt(System.IAsyncResult result)
        {
            return base.Channel.EndInsertEmprunt(result);
        }
        
        public WebsBO.EmpruntBO InsertRetour(string token, int pAdministrateurId, int pLivreId)
        {
            return base.Channel.InsertRetour(token, pAdministrateurId, pLivreId);
        }
        
        public System.IAsyncResult BeginInsertRetour(string token, int pAdministrateurId, int pLivreId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginInsertRetour(token, pAdministrateurId, pLivreId, callback, asyncState);
        }
        
        public WebsBO.EmpruntBO EndInsertRetour(System.IAsyncResult result)
        {
            return base.Channel.EndInsertRetour(result);
        }
        
        public WebsBO.EmpruntBO InsertAnnul(string token, int pAdministrateurId, int pReservationId)
        {
            return base.Channel.InsertAnnul(token, pAdministrateurId, pReservationId);
        }
        
        public System.IAsyncResult BeginInsertAnnul(string token, int pAdministrateurId, int pReservationId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginInsertAnnul(token, pAdministrateurId, pReservationId, callback, asyncState);
        }
        
        public WebsBO.EmpruntBO EndInsertAnnul(System.IAsyncResult result)
        {
            return base.Channel.EndInsertAnnul(result);
        }
    }
}
