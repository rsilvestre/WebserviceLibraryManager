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
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:WebsIFAC/ItemIFAC", ConfigurationName="WCF.Proxies.ItemIFAC")]
    public interface ItemIFAC
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectAll", ReplyAction="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectAllResponse")]
        System.Collections.Generic.List<WebsBO.ItemBO> SelectAll(string token);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectAll", ReplyAction="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectAllResponse")]
        System.IAsyncResult BeginSelectAll(string token, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.ItemBO> EndSelectAll(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectByItemId", ReplyAction="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectByItemIdResponse")]
        WebsBO.ItemBO SelectByItemId(string token, int pItemId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectByItemId", ReplyAction="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectByItemIdResponse")]
        System.IAsyncResult BeginSelectByItemId(string token, int pItemId, System.AsyncCallback callback, object asyncState);
        
        WebsBO.ItemBO EndSelectByItemId(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectByEmpruntId", ReplyAction="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectByEmpruntIdResponse")]
        WebsBO.ItemBO SelectByEmpruntId(string token, int pEmpruntId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectByEmpruntId", ReplyAction="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectByEmpruntIdResponse")]
        System.IAsyncResult BeginSelectByEmpruntId(string token, int pEmpruntId, System.AsyncCallback callback, object asyncState);
        
        WebsBO.ItemBO EndSelectByEmpruntId(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectByAdministrateurId", ReplyAction="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectByAdministrateurIdResponse")]
        System.Collections.Generic.List<WebsBO.ItemBO> SelectByAdministrateurId(string token, int pAdministrateurId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectByAdministrateurId", ReplyAction="urn:WebsIFAC/ItemIFAC/ItemIFAC/SelectByAdministrateurIdResponse")]
        System.IAsyncResult BeginSelectByAdministrateurId(string token, int pAdministrateurId, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.ItemBO> EndSelectByAdministrateurId(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ItemIFACChannel : WCF.Proxies.ItemIFAC, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ItemIFACClient : System.ServiceModel.ClientBase<WCF.Proxies.ItemIFAC>, WCF.Proxies.ItemIFAC
    {
        
        public ItemIFACClient()
        {
        }
        
        public ItemIFACClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public ItemIFACClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public ItemIFACClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public ItemIFACClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Collections.Generic.List<WebsBO.ItemBO> SelectAll(string token)
        {
            return base.Channel.SelectAll(token);
        }
        
        public System.IAsyncResult BeginSelectAll(string token, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectAll(token, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.ItemBO> EndSelectAll(System.IAsyncResult result)
        {
            return base.Channel.EndSelectAll(result);
        }
        
        public WebsBO.ItemBO SelectByItemId(string token, int pItemId)
        {
            return base.Channel.SelectByItemId(token, pItemId);
        }
        
        public System.IAsyncResult BeginSelectByItemId(string token, int pItemId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectByItemId(token, pItemId, callback, asyncState);
        }
        
        public WebsBO.ItemBO EndSelectByItemId(System.IAsyncResult result)
        {
            return base.Channel.EndSelectByItemId(result);
        }
        
        public WebsBO.ItemBO SelectByEmpruntId(string token, int pEmpruntId)
        {
            return base.Channel.SelectByEmpruntId(token, pEmpruntId);
        }
        
        public System.IAsyncResult BeginSelectByEmpruntId(string token, int pEmpruntId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectByEmpruntId(token, pEmpruntId, callback, asyncState);
        }
        
        public WebsBO.ItemBO EndSelectByEmpruntId(System.IAsyncResult result)
        {
            return base.Channel.EndSelectByEmpruntId(result);
        }
        
        public System.Collections.Generic.List<WebsBO.ItemBO> SelectByAdministrateurId(string token, int pAdministrateurId)
        {
            return base.Channel.SelectByAdministrateurId(token, pAdministrateurId);
        }
        
        public System.IAsyncResult BeginSelectByAdministrateurId(string token, int pAdministrateurId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectByAdministrateurId(token, pAdministrateurId, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.ItemBO> EndSelectByAdministrateurId(System.IAsyncResult result)
        {
            return base.Channel.EndSelectByAdministrateurId(result);
        }
    }
}