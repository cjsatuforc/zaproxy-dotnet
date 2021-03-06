﻿using System.Collections.Generic;
using ZAProxy.Infrastructure;

namespace ZAProxy.Components
{
    /// <summary>
    /// Component for testing protection against Cross Site Request Forgery.
    /// </summary>
    public class AntiCsrfComponent : ComponentBase
    {
        /// <summary>
        /// Initiates a new instance of the <see cref="AntiCsrfComponent"/> class.
        /// </summary>
        /// <param name="zapProcess">The ZAP process to connect to.</param>
        public AntiCsrfComponent(IZapProcess zapProcess)
            : this(null, zapProcess)
        { }

        /// <summary>
        /// Initiates a new instance of the <see cref="AntiCsrfComponent"/> class with a specific HTTP client implementation.
        /// </summary>
        /// <param name="httpClient">The HTTP client implementation.</param>
        /// <param name="zapProcess">The ZAP process to connect to.</param>
        public AntiCsrfComponent(IHttpClient httpClient, IZapProcess zapProcess)
            : base(httpClient, zapProcess, "acsrf")
        { }

        #region Views

        /// <summary>
        /// Gets all CSRF token names that are used in scanning/fuzzing.
        /// </summary>
        /// <returns>The CSRF token names used.</returns>
        public IEnumerable<string> GetOptionTokenNames()
        {
            return ParseJsonListString(CallView<string>("optionTokensNames", "TokensNames"));
        }

        #endregion

        #region Actions

        /// <summary>
        /// Adds a CSRF token name to the list of names that are used in scanning/fuzzing.
        /// </summary>
        /// <param name="name">The token name to add.</param>
        public void AddOptionTokenName(string name)
        {
            CallAction("addOptionToken", new Parameters
            {
                { "String", name }
            });
        }

        /// <summary>
        /// Removes a CSRF token name from the list of names that are used in scanning/fuzzing.
        /// </summary>
        /// <param name="name">The token name to remove.</param>
        public void RemoveOptionTokenName(string name)
        {
            CallAction("removeOptionToken", new Parameters
            {
                { "String", name }
            });
        }

        #endregion

        #region Others
        
        /// <summary>
        /// Generates an HTML page with a form to fuzz/test a specific POST message.
        /// </summary>
        /// <remarks>
        /// This method is mainly for internal use by ZAP.
        /// </remarks>
        /// <param name="messageId">The ID of a historic POST message to create this form for.</param>
        /// <returns>HTML to render a form for the specified POST message.</returns>
        public string GenerateForm(int messageId)
        {
            return CallOther("genForm", new Parameters
            {
                { "hrefId", messageId }
            });
        }

        #endregion
    }
}
