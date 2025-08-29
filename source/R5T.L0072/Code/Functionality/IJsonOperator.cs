using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0072
{
    /// <summary>
    /// .NET 6.0 strictly-framework library JSON operator built around System.Text.Json functionality.
    /// </summary>
    /// <remarks>
    /// JSON functionality in .NET was previously through the Json.NET third-party library.
    /// This was crazy, since the official ASP.NET Core framework actually depended on the third-party Json.NET library!
    /// As of .NET Core 3.0 (see <inheritdoc cref="Links.ForSysmteTextJsonFrameworkAvailability" path="/summary"/>),
    /// JSON functionality in .NET has been brought into the framework.
    /// </remarks>
    [FunctionalityMarker]
    public partial interface IJsonOperator : IFunctionalityMarker
    {
        public T Deserialize_FromText<T>(string jsonText)
        {
            var output = JsonSerializer.Deserialize<T>(jsonText);
            return output;
        }

        public JsonObject Parse_Object_FromJsonText(string jsonText)
        {
            var output = JsonObject.Parse(jsonText).AsObject();
            return output;
        }

        public T Parse_FromJsonText<T>(
            string jsonText,
            string keyName)
        {
            var jsonObject = this.Parse_Object_FromJsonText(jsonText);

            var jsonNode = jsonObject[keyName];

            var output = jsonNode.GetValue<T>();
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Parse_Object_FromJsonText(string)"/>.
        /// </summary>
        public JsonObject Parse_FromJsonText(string jsonText)
            => this.Parse_Object_FromJsonText(jsonText);

        public JsonNode Parse_AsNode(string jsonText)
        {
            var output = JsonObject.Parse(jsonText);
            return output;
        }

        public JsonArray Parse_AsArray(string jsonText)
        {
            var node = this.Parse_AsNode(jsonText);

            var output = node.AsArray();
            return output;
        }

        public JsonDocument Parse_AsDocument(string jsonText)
        {
            var output = JsonDocument.Parse(jsonText);
            return output;
        }

        public JsonElement Parse_AsElement(string jsonText)
        {
            var document = this.Parse_AsDocument(jsonText);

            var output = document.RootElement;
            return output;
        }

        public JsonObject Parse_AsObject(string jsonText)
        {
            var node = this.Parse_AsNode(jsonText);

            var output = node.AsObject();
            return output;
        }

        public JsonValue Parse_AsValue(string jsonText)
        {
            var node = this.Parse_AsNode(jsonText);

            var output = node.AsValue();
            return output;
        }

        public async Task<JsonDocument> Deserialize_AsJsonDocument(string jsonFilePath)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Read(
                jsonFilePath);

            var output = await JsonDocument.ParseAsync(fileStream);
            return output;
        }

        public JsonDocument Deserialize_Text_AsJsonDocument(string jsonText)
        {
            var output = JsonDocument.Parse(jsonText);
            return output;
        }

        public async Task<JsonElement> Deserialize_AsJsonElement(string jsonFilePath)
        {
            using var document = await this.Deserialize_AsJsonDocument(jsonFilePath);

            // Always return a clone of the element you want, since the JsonDocument is disposable.
            var output = document.RootElement.Clone();
            return output;
        }

        public JsonElement Deserialize_Text_AsJsonElement(string jsonText)
        {
            using var document = this.Deserialize_Text_AsJsonDocument(jsonText);

            // Always return a clone of the element you want, since the JsonDocument is disposable.
            var output = document.RootElement.Clone();
            return output;
        }

        public JsonSerializerOptions Get_Options_Standard()
        {
            var output = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return output;
        }

        public string Get_PropertyValue(
            JsonElement jElement,
            string propertyName)
        {
            var propertyJElement = jElement.GetProperty(propertyName);

            var output = propertyJElement.GetString();
            return output;
        }

        public string Get_Value_ByKeyPathParts(
            JsonElement jElement,
            params string[] keyPathParts)
        {
            var currentJElement = jElement;

            foreach (string keyPathPart in keyPathParts)
            {
                if (currentJElement.TryGetProperty(
                    keyPathPart,
                    out JsonElement nextJElement))
                {
                    currentJElement = nextJElement;
                }
                else
                {
                    throw new Exception($"Key not found: '{keyPathPart}'");
                }
            }

            var output = Instances.JsonElementOperator.Get_Value(currentJElement);
            return output;
        }

        public Task Serialize<T>(
            string jsonFilePath,
            T value)
            => this.Serialize_ToFile<T>(
                jsonFilePath,
                value);

        public Task Serialize_ToFile<T>(
            string jsonFilePath,
            T value)
            => this.Save_ToFile(
                jsonFilePath,
                value);

        public string Serialize_ToText(
            JsonObject jsonObject,
            JsonSerializerOptions options)
            // Just reuse the generic logic.
            => this.Serialize_ToText<JsonObject>(
                jsonObject,
                options);

        public string Serialize_ToText(JsonObject jsonObject)
        {
            var options = this.Get_Options_Standard();

            var output = this.Serialize_ToText(
                jsonObject,
                options);

            return output;
        }

        public string Serialize_ToText<T>(
            T value,
            JsonSerializerOptions options)
        {
            var jsonText = Instances.StringOperator.Serialize_UsingMemoryStream(
                memoryStream =>
                {
                    JsonSerializer.Serialize(
                        memoryStream,
                        value,
                        options);
                });

            return jsonText;
        }

        public string Serialize_ToText<T>(T value)
        {
            var options = this.Get_Options_Standard();

            var output = this.Serialize_ToText(
                value,
                options);

            return output;
        }

        public Task Serialize(
            string jsonFilePath,
            JsonElement element)
        {
            var options = this.Get_Options_Standard();

            return this.Serialize(
                jsonFilePath,
                element,
                options);
        }

        public async Task Serialize(
            string jsonFilePath,
            JsonElement element,
            JsonSerializerOptions options)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Write(
                jsonFilePath);

            await JsonSerializer.SerializeAsync(
                fileStream,
                element,
                options);
        }

        public Task Serialize(
            string jsonFilePath,
            JsonObject jsonObject)
        {
            var options = this.Get_Options_Standard();

            return this.Serialize(
                jsonFilePath,
                jsonObject,
                options);
        }

        public async Task Serialize(
            string jsonFilePath,
            JsonObject jsonObject,
            JsonSerializerOptions options)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Write(
                jsonFilePath);

            await JsonSerializer.SerializeAsync(
                fileStream,
                jsonObject,
                options);
        }

        public async Task<Dictionary<TKey, TValue>> Load_FromFile_ByKey<TKey, TValue>(
            string jsonFilePath,
            Func<TValue, TKey> keySelector)
        {
            try
            {
                var values = await this.Load_FromFile<TValue[]>(
                    jsonFilePath);

                var output = values
                    .ToDictionary(keySelector);

                return output;
            }
            catch (Exception exception)
            {
                throw this.Get_Exception_LoadFromFileFailed<TValue>(
                    jsonFilePath,
                    exception);
            }
        }

        public async Task<Dictionary<TKey, TValue[]>> Load_FromFile_GroupedByKey<TKey, TValue>(
            string jsonFilePath,
            Func<TValue, TKey> keySelector)
        {
            try
            {
                var values = await this.Load_FromFile<TValue[]>(
                    jsonFilePath);

                var output = values
                    .GroupBy(keySelector)
                    .ToDictionary(
                        group => group.Key,
                        group => group.ToArray());

                return output;
            }
            catch (Exception exception)
            {
                throw this.Get_Exception_LoadFromFileFailed<TValue[]>(
                    jsonFilePath,
                    exception);
            }
        }

        public T Load_FromFile_Synchronous<T>(string jsonFilePath)
        {
            var jsonText = Instances.FileOperator.Read_Text_Synchronous(jsonFilePath);

            var output = JsonSerializer.Deserialize<T>(jsonText);
            return output;
        }

        public async Task<T> Load_FromFile<T>(string jsonFilePath)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Read(jsonFilePath);

            var output = await JsonSerializer.DeserializeAsync<T>(fileStream);
            return output;
        }

        public async Task<T> Load_FromFile_OrDefault_New<T>(
            string jsonFilePath)
            where T : new()
        {
            var fileExists = Instances.FileSystemOperator.Exists_File(jsonFilePath);
            if(!fileExists)
            {
                return new();
            }

            var output = await this.Load_FromFile<T>(jsonFilePath);
            return output;
        }

        public string Get_ExceptionMessage_LoadFromFileFailed<T>(string jsonFilePath)
        {
            var typeName = Instances.TypeNameOperator.Get_TypeNameOf<T>();

            var output = $"Failed to load type '{typeName}' from:\n{jsonFilePath}";
            return output;
        }

        public Exception Get_Exception_LoadFromFileFailed<T>(string jsonFilePath)
        {
            var message = this.Get_ExceptionMessage_LoadFromFileFailed<T>(jsonFilePath);

            var output = new Exception(message);
            return output;
        }

        public Exception Get_Exception_LoadFromFileFailed<T>(
            string jsonFilePath,
            Exception innerException)
        {
            var message = this.Get_ExceptionMessage_LoadFromFileFailed<T>(jsonFilePath);

            var output = new Exception(message);
            return output;
        }

        //public async Task<T> Load_FromFile<T>(
        //    string jsonFilePath,
        //    string key)
        //{
        //    var rootElement = await this.Deserialize_AsJsonElement(jsonFilePath);

        //    var element = rootElement.GetProperty(key);

        //    var output = element.Deserialize<T>();
        //    return output;
        //}

        public async Task<T> Load_FromFile<T>(
            string jsonFilePath,
            string objectKey)
        {
            var jsonText = await Instances.FileOperator.Read_Text(jsonFilePath);

            var rootElement = JsonSerializer.Deserialize<JsonElement>(jsonText);

            var keyedElement = rootElement.GetProperty(objectKey);

            var output = keyedElement.Deserialize<T>();
            return output;
        }

        public T Load_FromFile_Synchronous<T>(
            string jsonFilePath,
            string objectKey)
        {
            var jsonText = Instances.FileOperator.Read_Text_Synchronous(jsonFilePath);

            var rootElement = JsonSerializer.Deserialize<JsonElement>(jsonText);

            var keyedElement = rootElement.GetProperty(objectKey);

            var output = keyedElement.Deserialize<T>();
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Deserialize_FromText{T}(string)"/>
        /// </summary>
        public T Load_FromString<T>(string jsonString)
            => this.Deserialize_FromText<T>(jsonString);

        public JsonArray New_Array(IEnumerable<JsonNode> nodes)
            => this.New_Array(nodes.ToArray());

        public JsonArray New_Array(params JsonNode[] nodes)
            => new(nodes);

        public JsonObject New_Object()
            => new();

        public void Save_ToFile_Synchronous<T>(
            string jsonFilePath,
            T value)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Write(
                jsonFilePath);

            JsonSerializer.Serialize(
                fileStream,
                value);
        }

        public async Task Save_ToFile<T>(
            string jsonFilePath,
            T value,
            JsonSerializerOptions options)
        {
            // "await using" because file steam is IAsyncDisposable.
            await using var fileStream = Instances.FileStreamOperator.Open_Write(
                jsonFilePath);

            await JsonSerializer.SerializeAsync(
                fileStream,
                value,
                options);
        }

        public Task Save_ToFile<T>(
            string jsonFilePath,
            T value)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return this.Save_ToFile<T>(
                jsonFilePath,
                value,
                options);
        }

        public string Save_ToString<T>(T value)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var output = JsonSerializer.Serialize(
                value,
                options);

            return output;
        }
    }
}
