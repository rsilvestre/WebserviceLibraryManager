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
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:WebsIFAC/BibliothequeIFAC", ConfigurationName="WCF.Proxies.BibliothequeIFAC")]
    public interface BibliothequeIFAC
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/BibliothequeIFAC/BibliothequeIFAC/SelectAll", ReplyAction="urn:WebsIFAC/BibliothequeIFAC/BibliothequeIFAC/SelectAllResponse")]
        System.Collections.Generic.List<WebsBO.BibliothequeBO> SelectAll(string Token);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/BibliothequeIFAC/BibliothequeIFAC/SelectAll", ReplyAction="urn:WebsIFAC/BibliothequeIFAC/BibliothequeIFAC/SelectAllResponse")]
        System.IAsyncResult BeginSelectAll(string Token, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.BibliothequeBO> EndSelectAll(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface BibliothequeIFACChannel : WCF.Proxies.BibliothequeIFAC, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BibliothequeIFACClient : System.ServiceModel.ClientBase<WCF.Proxies.BibliothequeIFAC>, WCF.Proxies.BibliothequeIFAC
    {
        
        public BibliothequeIFACClient()
        {
        }
        
        public BibliothequeIFACClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public BibliothequeIFACClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public BibliothequeIFACClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public BibliothequeIFACClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Collections.Generic.List<WebsBO.BibliothequeBO> SelectAll(string Token)
        {
            return base.Channel.SelectAll(Token);
        }
        
        public System.IAsyncResult BeginSelectAll(string Token, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectAll(Token, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.BibliothequeBO> EndSelectAll(System.IAsyncResult result)
        {
            return base.Channel.EndSelectAll(result);
        }
    }
}