using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Piksel.SettingsHelper;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace Piksel.Dearchiver.Properties
{
    [MetadataType(typeof(SettingsMetadata))]
    public sealed partial class Settings
    {
        public Settings()
        {
            TypeDescriptor.AddProvider(new SettingsDescriptorProvider(typeof(Settings)), typeof(Settings));
        }

#pragma warning disable RCS1033, RCS1049, RCS1156 // We dont want this to do antything but compare with the default.
        private bool ShouldSerializeOpenFolderAfterExtract() => OpenFolderAfterExtract != true;
        private bool ShouldSerializeCloseAppAfterExtract() => CloseAppAfterExtract != true;
        private bool ShouldSerializeConvertDeleteArchAfterExtract() => ConvertDeleteArchAfterExtract != true;
        private bool ShouldSerializeExtWADeleteArchAfterExtract() => ExtWADeleteArchAfterExtract != false;
        private bool ShouldSerializeWorkingAreaBasePath() => WorkingAreaBasePath != "";
        private bool ShouldSerializeExternalArchiverPath() => ExternalArchiverPath != "";
        private bool ShouldSerializeExternalArchiverName() => ExternalArchiverName != "";
        private bool ShouldSerializeExternalArchiverArgs() => ExternalArchiverArgs != "\"%1\"";
        private bool ShouldSerializeExternalArchiverAutomatic() => ExternalArchiverAutomatic != true;
#pragma warning restore RCS1156, RCS1049, RCS1033

        public sealed class SettingsMetadata
        {
            [Category("After Extraction")]
            [DisplayName("Open folder")]
            [Description("Should the extracted folder be opened after extraction?")]
            [DefaultValue(true)]
            [TypeConverter(typeof(BooleanConverterYesNo))]
            public bool OpenFolderAfterExtract { get; set; }

            [Category("After Extraction")]
            [DisplayName("Close Dearchiver")]
            [Description("Should Dearchiver be closed after extraction?")]
            [DefaultValue(true)]
            [TypeConverter(typeof(BooleanConverterYesNo))]
            public bool CloseAppAfterExtract { get; set; }

            [Category("After Extraction")]
            [DisplayName("Delete archive (convert)")]
            [Description("Should the archive be deleted after conversion?\nIf this is turned off both Foo.zip and Foo\\ will be present.")]
            [DefaultValue(true)]
            [TypeConverter(typeof(BooleanConverterYesNo))]
            public bool ConvertDeleteArchAfterExtract { get; set; }

            [Category("After Extraction")]
            [DisplayName("Delete archive (extract to w/e)")]
            [Description("Should the archive be deleted after extraction to working area?")]
            [DefaultValue(false)]
            [TypeConverter(typeof(BooleanConverterYesNo))]
            public bool ExtWADeleteArchAfterExtract { get; set; }

            [Category("Working Area")]
            [DisplayName("Base Path")]
            [Description("\"Working Area\" folders will be created in this path.\nExample: If the path is \"c:\\work\", first working area will be \"c:\\work\\001\" ")]
            [DefaultValue("")]
            public bool WorkingAreaBasePath { get; set; }

            [Category("External Archiver")]
            [DisplayName("Path")]
            [Description("Path to external archiver binary.")]
            [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
            [DefaultValue("")]
            public bool ExternalArchiverPath { get; set; }

            [Category("External Archiver")]
            [DisplayName("Name")]
            [Description("")]
            [DefaultValue("")]
            public bool ExternalArchiverName { get; set; }

            [Category("External Archiver")]
            [DisplayName("Arguments")]
            [Description("")]
            [DefaultValue("\"%1\"")]
            public bool ExternalArchiverArgs { get; set; }

            [Category("External Archiver")]
            [DisplayName("Use default (7Zip/explorer)")]
            [Description("Use 7zip from registry path or fall back on explorer as the external archiver.\nNote: Overrides Path, Name and Arguments")]
            [DefaultValue(true)]
            [TypeConverter(typeof(BooleanConverterYesNo))]
            public bool ExternalArchiverAutomatic { get; set; }

            [Browsable(false)]
            public bool Upgraded { get; set; }
        }
    }
}
