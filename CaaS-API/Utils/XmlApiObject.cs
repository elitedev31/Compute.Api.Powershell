using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace CaaSAPI.Utils
{
    /// <summary>
    /// Provides a universal data transfer object for moving xml across service boundaries.
    /// </summary>
    [Serializable]
    public class XmlApiObject
    {
        private string _xml;
        private string _rootTypeFqn;


        /// <summary>
        /// Gets or sets the XML.
        /// </summary>
        /// <value>
        /// The XML.
        /// </value>
        public string Xml
        {
            get { return _xml; }
            set { _xml = value; }
        }

        /// <summary>
        /// Gets or sets the root type FQN.
        /// </summary>
        /// <value>
        /// The root type FQN.
        /// </value>
        public string RootTypeFqn
        {
            get { return _rootTypeFqn; }
            set { _rootTypeFqn = value; }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return _xml;
        }

        /// <summary>
        /// Generates a TModel instance by deserializing the given xml string.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="xml">The XML.</param>
        /// <returns></returns>
        public static XmlApiObject FromXmlString<TModel>(string xml) where TModel:class
        {

            XmlApiObject obj = new XmlApiObject();
            obj.Xml = xml;
            obj.RootTypeFqn = typeof(TModel).AssemblyQualifiedName;

            XmlSerializer serializer = new XmlSerializer(typeof(TModel));
            
            using (StringReader reader = new StringReader(xml))
            {
                XmlReader xmlReader = XmlReader.Create(reader);
                if (!serializer.CanDeserialize(xmlReader))
                {
                    throw new Exception("FromXmlString error");
                }
            }

            return obj;            
        }

    }
}
