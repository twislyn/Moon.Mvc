﻿using System.Collections.Generic;



namespace System.Web.WebPages.Html {
    public partial class HtmlHelper {
        public IHtmlString Label(string labelText) {
            return Label(labelText, null, (IDictionary<string, object>)null);
        }

        public IHtmlString Label(string labelText, string labelFor) {
            return Label(labelText, labelFor, (IDictionary<string, object>)null);
        }

        public IHtmlString Label(string labelText, object attributes) {
            return Label(labelText, null, ObjectToDictionary(attributes));
        }

        public IHtmlString Label(string labelText, string labelFor, object attributes) {
            return Label(labelText, labelFor, ObjectToDictionary(attributes));
        }

        public IHtmlString Label(string labelText, string labelFor, IDictionary<string, object> attributes) {
            if (String.IsNullOrEmpty(labelText)) {
                throw new ArgumentException(CommonResources.Argument_Cannot_Be_Null_Or_Empty, "labelText");
            }

            labelFor = labelFor ?? labelText;

            TagBuilder tag = new TagBuilder("label") { InnerHtml = Encode(labelText) };
                        
            if (!String.IsNullOrEmpty(labelFor)) {
                tag.MergeAttribute("for", labelFor);
            }
            tag.MergeAttributes(attributes, false);

            return tag.ToHtmlString(TagRenderMode.Normal);
        }
    }
}
