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
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:WebsIFAC/LivreIFAC", ConfigurationName="WCF.Proxies.LivreIFAC")]
    public interface LivreIFAC
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectAll", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectAllResponse")]
        System.Collections.Generic.List<WebsBO.LivreBO> SelectAll();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectAll", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectAllResponse")]
        System.IAsyncResult BeginSelectAll(System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.LivreBO> EndSelectAll(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/InsertLivre", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/InsertLivreResponse")]
        WebsBO.LivreBO InsertLivre(WebsBO.LivreBO pObjLivre);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/InsertLivre", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/InsertLivreResponse")]
        System.IAsyncResult BeginInsertLivre(WebsBO.LivreBO pObjLivre, System.AsyncCallback callback, object asyncState);
        
        WebsBO.LivreBO EndInsertLivre(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface LivreIFACChannel : WCF.Proxies.LivreIFAC, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LivreIFACClient : System.ServiceModel.ClientBase<WCF.Proxies.LivreIFAC>, WCF.Proxies.LivreIFAC
    {
        
        public LivreIFACClient()
        {
        }
        
        public LivreIFACClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public LivreIFACClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public LivreIFACClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public LivreIFACClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Collections.Generic.List<WebsBO.LivreBO> SelectAll()
        {
            return base.Channel.SelectAll();
        }
        
        public System.IAsyncResult BeginSelectAll(System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectAll(callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.LivreBO> EndSelectAll(System.IAsyncResult result)
        {
            return base.Channel.EndSelectAll(result);
        }
        
        public WebsBO.LivreBO InsertLivre(WebsBO.LivreBO pObjLivre)
        {
            return base.Channel.InsertLivre(pObjLivre);
        }
        
        public System.IAsyncResult BeginInsertLivre(WebsBO.LivreBO pObjLivre, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginInsertLivre(pObjLivre, callback, asyncState);
        }
        
        public WebsBO.LivreBO EndInsertLivre(System.IAsyncResult result)
        {
            return base.Channel.EndInsertLivre(result);
        }
    }
}
