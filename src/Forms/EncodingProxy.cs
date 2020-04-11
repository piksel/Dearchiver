using System.Text;

namespace Piksel.Dearchiver.Forms
{
    internal class EncodingProxy
    {
        //
        // Summary:
        //     Gets the name registered with the Internet Assigned Numbers Authority (IANA)
        //     for the encoding.
        //
        // Returns:
        //     The IANA name for the encoding. For more information about the IANA, see www.iana.org.
        public string Name { get; }
        //
        // Summary:
        //     Gets the human-readable description of the encoding.
        //
        // Returns:
        //     The human-readable description of the encoding.
        public string DisplayName { get; }

        public EncodingProxy(EncodingInfo ei)
        {
            Name = ei.Name;
            DisplayName = $"{ei.DisplayName} ({Name})";
        }

        public Encoding Encoding => Encoding.GetEncoding(Name);

        public override string ToString() => DisplayName;
        
    }
}