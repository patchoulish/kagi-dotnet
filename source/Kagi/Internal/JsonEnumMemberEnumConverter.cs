using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime;
using System.Runtime.Serialization;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace Kagi.Internal
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TEnum"></typeparam>
	internal sealed class JsonEnumMemberEnumConverter<TEnum> :
		JsonConverter<TEnum>
			where TEnum :
				struct,
				Enum
	{
		private readonly IDictionary<TEnum, string> jsonValues;

		/// <summary>
		/// 
		/// </summary>
		public JsonEnumMemberEnumConverter() :
			base()
		{
			this.jsonValues =
				new Dictionary<TEnum, string>();

			foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
			{
				this.jsonValues[value] =
					typeof(TEnum)
						.GetMember(value.ToString())
						.FirstOrDefault()?
						.GetCustomAttribute<EnumMemberAttribute>()?
						.Value;
			}
		}

		/// <inheritdoc />
		public sealed override bool CanConvert(
			Type typeToConvert) =>
				(typeToConvert == typeof(TEnum));

		/// <inheritdoc />
		public override TEnum Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			var jsonValue =
				reader.GetString();

			foreach (var kvp in this.jsonValues)
			{
				if (kvp.Value.Equals(
					jsonValue,
					StringComparison.OrdinalIgnoreCase))
				{
					return kvp.Key;
				}
			}

			throw new JsonException(
				$"Unable to convert \"{jsonValue}\" to {typeof(TEnum)}.");
		}

		/// <inheritdoc />
		public override void Write(
			Utf8JsonWriter writer,
			TEnum value,
			JsonSerializerOptions options)
		{
			if (this.jsonValues
				.TryGetValue(
					value,
					out var jsonValue))
			{
				writer.WriteStringValue(
					jsonValue);
			}
			else
			{
				throw new JsonException(
					$"Unable to convert \"{value}\" to JSON.");
			}
		}
	}
}
