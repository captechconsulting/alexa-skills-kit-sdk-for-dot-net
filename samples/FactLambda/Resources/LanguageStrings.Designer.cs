﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FactLambda.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LanguageStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LanguageStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FactLambda.Resources.LanguageStrings", typeof(LanguageStrings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, an error occurred..
        /// </summary>
        internal static string ErrorMessage {
            get {
                return ResourceManager.GetString("ErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A year on Mercury is just 88 days long.|Despite being farther from the Sun, Venus experiences higher temperatures than Mercury.|On Mars, the Sun appears about half the size as it does on Earth.|Jupiter has the shortest day of all the planets.|The Sun is an almost perfect sphere..
        /// </summary>
        internal static string Facts {
            get {
                return ResourceManager.GetString("Facts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Space Facts skill can&apos;t help you with that.  It can help you discover facts about space if you say tell me a space fact. What can I help you with?.
        /// </summary>
        internal static string FallbackMessage {
            get {
                return ResourceManager.GetString("FallbackMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to What can I help you with?.
        /// </summary>
        internal static string FallbackReprompt {
            get {
                return ResourceManager.GetString("FallbackReprompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Here&apos;s your fact: .
        /// </summary>
        internal static string GetFactMessage {
            get {
                return ResourceManager.GetString("GetFactMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You can say tell me a space fact, or, you can say exit... What can I help you with?.
        /// </summary>
        internal static string HelpMessage {
            get {
                return ResourceManager.GetString("HelpMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to What can I help you with?.
        /// </summary>
        internal static string HelpReprompt {
            get {
                return ResourceManager.GetString("HelpReprompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Space Facts.
        /// </summary>
        internal static string SkillName {
            get {
                return ResourceManager.GetString("SkillName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Goodbye!.
        /// </summary>
        internal static string StopMessage {
            get {
                return ResourceManager.GetString("StopMessage", resourceCulture);
            }
        }
    }
}