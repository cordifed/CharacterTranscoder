
//
// EncodingTypeConverter.cs
//
// Author:
//    Tomas Restrepo (tomasr@mvps.org)
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Globalization;
using System.Text;

namespace Winterdom.BizTalk.Samples.FixEncoding.Design
{
   /// <summary>
   /// Simple type converter to present encoding values.
   /// </summary>
   class EncodingTypeConverter : TypeConverter
   {
      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
      {
          return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
      }

      public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
      {
          return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
      }

      public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
      {
          if (!(value is string)) return base.ConvertFrom(context, culture, value);
          var text = ((string)value).Trim();
          return Encoding.GetEncoding(text);
      }

      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
      {
         if ( destinationType == null )
         {
            throw new ArgumentNullException("destinationType");
         }
         var enc = value as Encoding;
         if ( (destinationType == typeof(string)) && (enc != null) )
         {
            return enc.EncodingName;
         }
         return base.ConvertTo(context, culture, value, destinationType);
      }
 



   } // class EncodingTypeConverter

} // namespace Winterdom.BizTalk.Samples.FixEncoding.Design

