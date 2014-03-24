using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace CaaSAPI.Utils
{
    /// <summary>
    /// Provides extension factory methods that project Models into ApiObjects.
    /// </summary>
    public static class XmlApiObjectExtensions
    {
        /// <summary>
        /// Creates an XMLApiObject based on the given rootObject.
        /// </summary>
        /// <typeparam name="TRoot">The type of the root object for the xml serialization.</typeparam>
        /// <param name="rootObject">The root object.</param>
        /// <param name="xml">The XML.</param>
        /// <returns></returns>
        public static XmlApiObject ProjectToXmlApiObject<TRoot>(this TRoot rootObject) where TRoot : class
        {
            if (rootObject is XmlApiObject)
                return rootObject as XmlApiObject; // not much to do in that case...

            Type rootObjectType = typeof(TRoot);
            XmlSerializer serializer = new XmlSerializer(rootObjectType);
            XmlApiObject apiObject = new XmlApiObject();
            apiObject.RootTypeFqn = rootObjectType.AssemblyQualifiedName;

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, rootObject);
                apiObject.Xml = writer.ToString();
            }

            return apiObject;
        }

        /// <summary>
        /// Creates an XMLApiObject based on the given rootObject with specific xml setting
        /// </summary>
        /// <typeparam name="TRoot">The type of the root.</typeparam>
        /// <param name="rootObject">The root object.</param>
        /// <param name="XmlSetting">The xml setting.</param>
        /// <param name="defaultNameSpace">The default namespace.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlApiObject ProjectToXmlApiObject<TRoot>(this TRoot rootObject, XmlWriterSettings XmlSetting) where TRoot : class
        {
            Type rootObjectType = typeof(TRoot);
            XmlSerializer serializer = new XmlSerializer(rootObjectType);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlApiObject apiObject = new XmlApiObject();
            apiObject.RootTypeFqn = rootObjectType.AssemblyQualifiedName;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, XmlSetting))
            {
                serializer.Serialize(writer, rootObject, ns);
                apiObject.Xml = stream.ToString();
            }

            return apiObject;
        }


        /// <summary>
        /// Deserializes the given XmlApiObject into the corresponding model class given by TModel.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="apiObject">The API object.</param>
        /// <returns></returns>
        public static TModel ProjectFromXmlApiObject<TModel>(this XmlApiObject apiObject) where TModel : class
        {
            TModel model;
            XmlSerializer serializer = new XmlSerializer(typeof(TModel));

            using (StringReader reader = new StringReader(apiObject.Xml))
            {
                model = serializer.Deserialize(reader) as TModel;
            }

            return model;
        }
    }
}
