using System.IO;
using Piksel.Dearchiver.Helpers;
using System.Collections.Generic;
using EntryNode = Piksel.Dearchiver.Extractor.DirectoryWindow.EntryNode;

namespace Piksel.Dearchiver
{

    internal sealed class NodeInfo
    {
        public EntryNode Node { get; }
        public int IconIndex { get; }
        public string TypeName { get; }

        public string Name => Node.Name;
        public string FileSize { get; }
        public string CompressedSize { get; }
        public string DateTime { get; }
        public IEnumerable<EntryNode> ChildNodes;

        private NodeInfo(EntryNode node, IEnumerable<EntryNode> childNodes, bool rootNode) {

            string path;
            FileAttributes attribs;
            const bool link = false; // Fix if ZipEntry starts supporting links

            if (!rootNode && node.IsDirectory)
            {
                path = "";
                attribs = FileAttributes.Directory;

            }
            else
            {
                attribs = FileAttributes.Normal;
                path = path = PathEx.GetFileExtension(node.Name);
                if (string.IsNullOrEmpty(path))
                {
                    path = "";
                }
            }

            var fileInfo = IconExtractor.GetFileInfo(path, false, link, attribs);

            IconIndex = fileInfo.IconIndex;
            FileSize = StorageSizeFormatter.FormatSuffixed(node.Size, 2, true);
            CompressedSize = StorageSizeFormatter.FormatSuffixed(node.CompressedSize, 2, true);
            DateTime = node.DateTime.ToString("yyyy-MM-dd HH:mm");
            TypeName = fileInfo.TypeName;

            Node = node;
            if (childNodes != null)
                ChildNodes = childNodes;
            else if (node.ChildNodes != null)
                ChildNodes = node.ChildNodes?.Values;
            else
                ChildNodes = new EntryNode[0];
        }

        public static NodeInfo FromNode(EntryNode node)
            => new NodeInfo(node, null, false);

        internal static NodeInfo CreateRootNode(string name, IEnumerable<EntryNode> childNodes)
        {
            var rootNode = EntryNode.CreateRootNode(name);
            return new NodeInfo(rootNode, childNodes, true);
        }
    }

}
