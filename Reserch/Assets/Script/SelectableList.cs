using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// �ύX�����m�\�ȃ��X�g
/// </summary>
public class SelectableList<T> : IList<T>
{
    private List<T> mList; // ���X�g

    /// <summary>
    /// �w�肵���C���f�b�N�X�ɂ���v�f���擾�܂��͐ݒ肵�܂�
    /// </summary>
    public T this[int index]
    {
        get { return mList[index]; }
        set
        {
            mList[index] = value;
            OnChanged();
        }
    }



    /// <summary>
    /// ���X�g�Ɋi�[����Ă���v�f�̐����擾���܂�
    /// </summary>
    public int Count { get { return mList.Count; } }

    /// <summary>
    /// ���X�g���ǂݎ���p���ǂ����������l���擾���܂�
    /// </summary>
    public bool IsReadOnly { get { return false; } }

    /// <summary>
    /// �ύX���ꂽ���ɌĂяo����܂�
    /// </summary>
#pragma warning disable 0067
    public Action mChanged;
#pragma warning restore 0067

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public SelectableList()
    {
        mList = new List<T>();
    }

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public SelectableList(params T[] collection)
    {
        mList = new List<T>(collection);
    }

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public SelectableList(IList<T> collection)
    {
        mList = new List<T>(collection);
    }

    /// <summary>
    /// ���X�g�̗v�f��V�����z��ɃR�s�[���܂�
    /// </summary>
    public T[] ToArray()
    {
        return mList.ToArray();
    }

    /// <summary>
    /// ���X�g�̗v�f��V�������X�g�ɃR�s�[���܂�
    /// </summary>
    public List<T> ToList()
    {
        return mList.ToList();
    }

    public void copy(List<T> list)
    {
        mList = list;
        OnChanged();
    }

    /// <summary>
    /// <para>���X�g���܂��͂��̈ꕔ�ɂ���l�̂����A</para>
    ///<para> �ŏ��ɏo������l�́A0 ����n�܂�C���f�b�N�X�ԍ���Ԃ��܂�</para>
    /// </summary>
    public int IndexOf(T item)
    {
        return mList.IndexOf(item);
    }

    /// <summary>
    /// ���X�g���̎w�肵���C���f�b�N�X�̈ʒu�ɗv�f��}�����܂�
    /// </summary>
    public void Insert(int index, T item)
    {
        mList.Insert(index, item);
        OnChanged();
    }

    /// <summary>
    /// ���X�g�̎w�肵���C���f�b�N�X�ɂ���v�f���폜���܂�
    /// </summary>
    public void RemoveAt(int index)
    {
        mList.RemoveAt(index);
        OnChanged();
    }

    /// <summary>
    /// ���X�g�̖����ɃI�u�W�F�N�g��ǉ����܂�
    /// </summary>
    public void Add(T item)
    {
        mList.Add(item);
        OnChanged();
    }

    /// <summary>
    /// ���X�g���炷�ׂĂ̗v�f���폜���܂�
    /// </summary>
    public void Clear()
    {
        mList.Clear();
        OnChanged();
    }

    /// <summary>
    /// <para>���X�g���炷�ׂĂ̗v�f���폜���܂�</para>
    /// <para>�l�̐ݒ��� mChanged �C�x���g�͌Ăяo����܂���</para>
    /// </summary>
    public void ClearWithoutCallback()
    {
        mList.Clear();
    }

    /// <summary>
    /// �w�肳�ꂽ�v�f�����݂���ꍇ true ��Ԃ��܂�
    /// </summary>
    public bool Contains(T item)
    {
        return mList.Contains(item);
    }

    /// <summary>
    /// ���X�g�܂��͂��̈ꕔ��z��ɃR�s�[���܂�
    /// </summary>
    public void CopyTo(T[] array, int arrayIndex)
    {
        mList.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// ���X�g���ōŏ��Ɍ�����������̃I�u�W�F�N�g���폜���܂�
    /// </summary>
    public bool Remove(T item)
    {
        var result = mList.Remove(item);
        OnChanged();
        return result;
    }

    /// <summary>
    /// �w�肵���q��ɂ���Ē�`���������Ɉ�v���邷�ׂĂ̗v�f���폜���܂�
    /// </summary>
    public void RemoveAll(Predicate<T> match)
    {
        mList.RemoveAll(match);
        OnChanged();
    }

    /// <summary>
    /// <para>���X�g�̖����ɃI�u�W�F�N�g��ǉ����܂�</para>
    /// <para>�w�肳�ꂽ�v�f�����݂���ꍇ�폜���܂�</para>
    /// </summary>
    public void AddOrRemove(T item)
    {
        if (Contains(item))
        {
            Remove(item);
        }
        else
        {
            Add(item);
        }
    }

    /// <summary>
    /// ���X�g�𔽕���������񋓎q��Ԃ��܂�
    /// </summary>
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return mList.GetEnumerator();
    }

    /// <summary>
    /// ���X�g�𔽕���������񋓎q��Ԃ��܂�
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return mList.GetEnumerator();
    }

    /// <summary>
    /// �l���ύX���ꂽ���ɌĂяo����܂�
    /// </summary>
    private void OnChanged()
    {
        var onChanged = mChanged;
        if (onChanged == null)
        {
            return;
        }
        onChanged();
    }


}