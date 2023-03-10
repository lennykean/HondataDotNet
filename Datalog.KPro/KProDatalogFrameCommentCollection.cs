using System.Collections;
using System.Collections.Generic;
using System.IO;

using HondataDotNet.Datalog.Core;

namespace HondataDotNet.Datalog.KPro
{
    public sealed class KProDatalogFrameCommentCollection : IReadWriteCollection<KProDatalogFrameComment>
    {
        private readonly SortedSet<KProDatalogFrameComment> _comments;

        private byte[] _header;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal KProDatalogFrameCommentCollection()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _comments = new(new TimeSeriesComparer());
        }

        public int Count => _comments.Count;

        public bool IsReadOnly => false;

        public void Add(KProDatalogFrameComment item)
        {
            _comments.Add(item);
        }

        public void Clear()
        {
            _comments.Clear();
        }

        public bool Contains(KProDatalogFrameComment item)
        {
            return _comments.Contains(item);
        }

        public void CopyTo(KProDatalogFrameComment[] array, int arrayIndex)
        {
            _comments.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KProDatalogFrameComment> GetEnumerator()
        {
            return _comments.GetEnumerator();
        }

        public bool Remove(KProDatalogFrameComment item)
        {
            return _comments.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal static KProDatalogFrameCommentCollection ReadFromStream(Stream stream, int commentCount)
        {
            var comments = new KProDatalogFrameCommentCollection();

            var header = new byte[4];
            stream.Read(header, 0, header.Length);
            comments._header = header;
            
            for (var i = 0; i < commentCount; i++)
            {
                comments.Add(KProDatalogFrameComment.ReadFromStream(stream));
            }
            return comments;
        }

        internal void Save(Stream stream)
        {
            stream.Write(_header);

            foreach (var comment in _comments)
            {
                comment.Save(stream);
            }
        }
    }
}
