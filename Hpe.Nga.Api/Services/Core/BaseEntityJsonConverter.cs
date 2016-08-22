using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Hpe.Nga.Api.Core.Services.Core
{
    /// <summary>
    /// Serailization and deserialization to JSON of classes that inherit <see cref="BaseEntity"/>
    /// </summary>
    public class BaseEntityJsonConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                List<Type> types = new List<Type>(EntityTypeRegistry.GetInstance().GetRegisteredTypes());
                types.Add(typeof(BaseEntity));


                return types;
            }
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (obj == null) return result;
            BaseEntity entity = ((BaseEntity)obj);
            return entity.GetProperties();
        }

        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            /*if (type == typeof(BaseEntity))
            {
                return new BaseEntity(dictionary);
            }*/
            BaseEntity entity = (BaseEntity)Activator.CreateInstance(type);
            entity.SetProperties(dictionary);

            foreach (var pair in dictionary)
            {
                if (pair.Value is Dictionary<String, Object>)
                {


                    Dictionary<String, Object> pairValue = (Dictionary<String, Object>)pair.Value;
                    if (pairValue.ContainsKey("total_count"))
                    {
                        EntityList<BaseEntity> entityList = new EntityList<BaseEntity>();
                        IList data = (IList)((Dictionary<String, Object>)pair.Value)["data"];
                        for (int i = 0; i < data.Count; i++)
                        {
                            Dictionary<String, Object> rawEntity = (Dictionary<String, Object>)data[i];
                            BaseEntity baseEntity = ConvertToBaseEntity(rawEntity);
                            entityList.data.Add(baseEntity);
                        }
                        entity.SetValue(pair.Key, entityList);
                    }
                    else //single entity, like listNode
                    {
                        BaseEntity baseEntity = ConvertToBaseEntity(pairValue);
                        entity.SetValue(pair.Key, baseEntity);
                    }


                }
            }

            return entity;
        }

        private static BaseEntity ConvertToBaseEntity(Dictionary<String, Object> rawEntity)
        {
            String entityTypeName = (String)rawEntity["type"];
            BaseEntity baseEntity = null;
            if (entityTypeName != null)
            {
                Type entityType = EntityTypeRegistry.GetInstance().GetTypeByEntityTypeName(entityTypeName);
                if (entityType != null)
                {
                    baseEntity = (BaseEntity)Activator.CreateInstance(entityType);
                }
            }
            if (baseEntity == null)
            {
                baseEntity = new BaseEntity();
            }

            baseEntity.SetProperties(rawEntity);
            return baseEntity;
        }


    }
}
