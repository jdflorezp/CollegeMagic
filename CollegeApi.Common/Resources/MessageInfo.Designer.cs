﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CollegeApi.Common.Resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MessageInfo {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MessageInfo() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CollegeApi.Common.Resources.MessageInfo", typeof(MessageInfo).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El Servicio no está disponible por el momento, por favor intente más tarde..
        /// </summary>
        public static string messageErrorGeneric {
            get {
                return ResourceManager.GetString("messageErrorGeneric", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El campo {0} solo debe contener numeros..
        /// </summary>
        public static string messageErrorNumber {
            get {
                return ResourceManager.GetString("messageErrorNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a La cantidad de caracteres del campo {0}, se pasa del limite permitido..
        /// </summary>
        public static string messageErrorSize {
            get {
                return ResourceManager.GetString("messageErrorSize", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El campo {0} solo debe contener letras..
        /// </summary>
        public static string messageErrorText {
            get {
                return ResourceManager.GetString("messageErrorText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El id de la casa candidata no se encuentra registrada..
        /// </summary>
        public static string messageHouseExists {
            get {
                return ResourceManager.GetString("messageHouseExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No existe un estudiante con el numero de identificacion enviado..
        /// </summary>
        public static string messageNotExist {
            get {
                return ResourceManager.GetString("messageNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El campo {0} es obligatorio..
        /// </summary>
        public static string messageObligatoryField {
            get {
                return ResourceManager.GetString("messageObligatoryField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Proceso realizado exitosamente..
        /// </summary>
        public static string messageOK {
            get {
                return ResourceManager.GetString("messageOK", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El estudiante ya se encuentra registrado..
        /// </summary>
        public static string messageUserExists {
            get {
                return ResourceManager.GetString("messageUserExists", resourceCulture);
            }
        }
    }
}