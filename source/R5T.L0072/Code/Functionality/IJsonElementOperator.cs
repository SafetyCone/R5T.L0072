using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using R5T.T0132;


namespace R5T.L0072
{
    [FunctionalityMarker]
    public partial interface IJsonElementOperator : IFunctionalityMarker
    {
        public T Deserialize<T>(JsonElement jsonElement)
            => jsonElement.Deserialize<T>();

        public IEnumerable<JsonElement> Enumerate_ChildAraryElements(JsonElement element)
            => element.EnumerateArray();

        public bool Has_ChildElement(
            JsonElement element,
            string childName)
        {
            var output = element.TryGetProperty(
                childName,
                out _);

            return output;
        }

        public JsonElement Get_ChildElement(
            JsonElement element,
            string childName)
        {
            var output = element.GetProperty(childName);
            return output;
        }

        public string Get_ChildElement_Value(
            JsonElement element,
            string childName)
        {
            var childElement = this.Get_ChildElement(
                element,
                childName);

            var output = childElement.GetString();
            return output;
        }

        public IEnumerable<JsonElement> Get_Elements(JsonElement element)
        {
            var output = element.EnumerateArray();
            return output;
        }

        public JsonElement Get_FirstChild(JsonElement element)
        {
            var hasFirstChild = this.Has_FirstChildElement(
                element,
                out var firstChild_OrDefault);

            if(!hasFirstChild)
            {
                throw new Exception("JSON element had no first child.");
            }

            return firstChild_OrDefault;
        }

        public string Get_Value_AsString(JsonElement jElement)
        {
            var output = jElement.GetString();
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_Value_AsString(JsonElement)"/> as the default.
        /// </summary>
        public string Get_Value(JsonElement jElement)
            => this.Get_Value_AsString(jElement);

        public bool Has_FirstChildElement(
            JsonElement element,
            out JsonElement firstChild_OrDefault)
        {
            firstChild_OrDefault = this.Get_Elements(element)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(firstChild_OrDefault);
            return output;
        }

        public JsonElement Serialize_AsConcreteType<T>(T value)
            => JsonSerializer.SerializeToElement(value, value.GetType());

        public JsonElement Serialize_AsDeclaredType<T>(T value)
            => JsonSerializer.SerializeToElement(value);

        /// <summary>
        /// Chooses <see cref="Serialize_AsConcreteType{T}(T)"/> as the default.
        /// </summary>
        public JsonElement Serialize<T>(T value)
            => this.Serialize_AsConcreteType(value);
    }
}
