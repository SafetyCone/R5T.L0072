using System;
using System.Collections.Generic;
using System.Text.Json;

using R5T.T0132;


namespace R5T.L0072
{
    [FunctionalityMarker]
    public partial interface IJsonElementOperator : IFunctionalityMarker
    {
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
    }
}
