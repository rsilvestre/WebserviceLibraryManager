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
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:WebsIFAC/RefLivreIFAC", ConfigurationName="WCF.Proxies.RefLivreIFAC")]
    public interface RefLivreIFAC
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/FindAmazonRefByISBN", ReplyAction="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/FindAmazonRefByISBNResponse")]
        System.Collections.Generic.List<WebsBO.RefLivreBO> FindAmazonRefByISBN(System.Collections.Generic.List<string> pISBNs);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/FindAmazonRefByISBN", ReplyAction="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/FindAmazonRefByISBNResponse")]
        System.IAsyncResult BeginFindAmazonRefByISBN(System.Collections.Generic.List<string> pISBNs, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.RefLivreBO> EndFindAmazonRefByISBN(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/FindAmazonRefByTitle", ReplyAction="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/FindAmazonRefByTitleResponse")]
        System.Collections.Generic.List<WebsBO.RefLivreBO> FindAmazonRefByTitle(string pTitle);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/FindAmazonRefByTitle", ReplyAction="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/FindAmazonRefByTitleResponse")]
        System.IAsyncResult BeginFindAmazonRefByTitle(string pTitle, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.RefLivreBO> EndFindAmazonRefByTitle(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/SelectAll", ReplyAction="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/SelectAllResponse")]
        System.Collections.Generic.List<WebsBO.RefLivreBO> SelectAll();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/SelectAll", ReplyAction="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/SelectAllResponse")]
        System.IAsyncResult BeginSelectAll(System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.RefLivreBO> EndSelectAll(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/InsertLivre", ReplyAction="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/InsertLivreResponse")]
        System.Collections.Generic.List<WebsBO.RefLivreBO> InsertLivre(string pISBN, string pTitre, string pDescription, string pAuteur, string pLangue, string pEditeur, System.DateTime pPublished, string pImageUrl);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/InsertLivre", ReplyAction="urn:WebsIFAC/RefLivreIFAC/RefLivreIFAC/InsertLivreResponse")]
        System.IAsyncResult BeginInsertLivre(string pISBN, string pTitre, string pDescription, string pAuteur, string pLangue, string pEditeur, System.DateTime pPublished, string pImageUrl, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.RefLivreBO> EndInsertLivre(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface RefLivreIFACChannel : WCF.Proxies.RefLivreIFAC, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RefLivreIFACClient : System.ServiceModel.ClientBase<WCF.Proxies.RefLivreIFAC>, WCF.Proxies.RefLivreIFAC
    {
        
        public RefLivreIFACClient()
        {
        }
        
        public RefLivreIFACClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public RefLivreIFACClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public RefLivreIFACClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public RefLivreIFACClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Collections.Generic.List<WebsBO.RefLivreBO> FindAmazonRefByISBN(System.Collections.Generic.List<string> pISBNs)
        {
            return base.Channel.FindAmazonRefByISBN(pISBNs);
        }
        
        public System.IAsyncResult BeginFindAmazonRefByISBN(System.Collections.Generic.List<string> pISBNs, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginFindAmazonRefByISBN(pISBNs, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.RefLivreBO> EndFindAmazonRefByISBN(System.IAsyncResult result)
        {
            return base.Channel.EndFindAmazonRefByISBN(result);
        }
        
        public System.Collections.Generic.List<WebsBO.RefLivreBO> FindAmazonRefByTitle(string pTitle)
        {
            return base.Channel.FindAmazonRefByTitle(pTitle);
        }
        
        public System.IAsyncResult BeginFindAmazonRefByTitle(string pTitle, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginFindAmazonRefByTitle(pTitle, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.RefLivreBO> EndFindAmazonRefByTitle(System.IAsyncResult result)
        {
            return base.Channel.EndFindAmazonRefByTitle(result);
        }
        
        public System.Collections.Generic.List<WebsBO.RefLivreBO> SelectAll()
        {
            return base.Channel.SelectAll();
        }
        
        public System.IAsyncResult BeginSelectAll(System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectAll(callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.RefLivreBO> EndSelectAll(System.IAsyncResult result)
        {
            return base.Channel.EndSelectAll(result);
        }
        
        public System.Collections.Generic.List<WebsBO.RefLivreBO> InsertLivre(string pISBN, string pTitre, string pDescription, string pAuteur, string pLangue, string pEditeur, System.DateTime pPublished, string pImageUrl)
        {
            return base.Channel.InsertLivre(pISBN, pTitre, pDescription, pAuteur, pLangue, pEditeur, pPublished, pImageUrl);
        }
        
        public System.IAsyncResult BeginInsertLivre(string pISBN, string pTitre, string pDescription, string pAuteur, string pLangue, string pEditeur, System.DateTime pPublished, string pImageUrl, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginInsertLivre(pISBN, pTitre, pDescription, pAuteur, pLangue, pEditeur, pPublished, pImageUrl, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.RefLivreBO> EndInsertLivre(System.IAsyncResult result)
        {
            return base.Channel.EndInsertLivre(result);
        }
    }
}
