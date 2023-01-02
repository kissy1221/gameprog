using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 変更を検知可能なリスト
/// </summary>
public class SelectableList<T> : IList<T>
{
    private List<T> mList; // リスト

    /// <summary>
    /// 指定したインデックスにある要素を取得または設定します
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
    /// リストに格納されている要素の数を取得します
    /// </summary>
    public int Count { get { return mList.Count; } }

    /// <summary>
    /// リストが読み取り専用かどうかを示す値を取得します
    /// </summary>
    public bool IsReadOnly { get { return false; } }

    /// <summary>
    /// 変更された時に呼び出されます
    /// </summary>
#pragma warning disable 0067
    public Action mChanged;
#pragma warning restore 0067

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public SelectableList()
    {
        mList = new List<T>();
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public SelectableList(params T[] collection)
    {
        mList = new List<T>(collection);
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public SelectableList(IList<T> collection)
    {
        mList = new List<T>(collection);
    }

    /// <summary>
    /// リストの要素を新しい配列にコピーします
    /// </summary>
    public T[] ToArray()
    {
        return mList.ToArray();
    }

    /// <summary>
    /// リストの要素を新しいリストにコピーします
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
    /// <para>リスト内またはその一部にある値のうち、</para>
    ///<para> 最初に出現する値の、0 から始まるインデックス番号を返します</para>
    /// </summary>
    public int IndexOf(T item)
    {
        return mList.IndexOf(item);
    }

    /// <summary>
    /// リスト内の指定したインデックスの位置に要素を挿入します
    /// </summary>
    public void Insert(int index, T item)
    {
        mList.Insert(index, item);
        OnChanged();
    }

    /// <summary>
    /// リストの指定したインデックスにある要素を削除します
    /// </summary>
    public void RemoveAt(int index)
    {
        mList.RemoveAt(index);
        OnChanged();
    }

    /// <summary>
    /// リストの末尾にオブジェクトを追加します
    /// </summary>
    public void Add(T item)
    {
        mList.Add(item);
        OnChanged();
    }

    /// <summary>
    /// リストからすべての要素を削除します
    /// </summary>
    public void Clear()
    {
        mList.Clear();
        OnChanged();
    }

    /// <summary>
    /// <para>リストからすべての要素を削除します</para>
    /// <para>値の設定後に mChanged イベントは呼び出されません</para>
    /// </summary>
    public void ClearWithoutCallback()
    {
        mList.Clear();
    }

    /// <summary>
    /// 指定された要素が存在する場合 true を返します
    /// </summary>
    public bool Contains(T item)
    {
        return mList.Contains(item);
    }

    /// <summary>
    /// リストまたはその一部を配列にコピーします
    /// </summary>
    public void CopyTo(T[] array, int arrayIndex)
    {
        mList.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// リスト内で最初に見つかった特定のオブジェクトを削除します
    /// </summary>
    public bool Remove(T item)
    {
        var result = mList.Remove(item);
        OnChanged();
        return result;
    }

    /// <summary>
    /// 指定した述語によって定義される条件に一致するすべての要素を削除します
    /// </summary>
    public void RemoveAll(Predicate<T> match)
    {
        mList.RemoveAll(match);
        OnChanged();
    }

    /// <summary>
    /// <para>リストの末尾にオブジェクトを追加します</para>
    /// <para>指定された要素が存在する場合削除します</para>
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
    /// リストを反復処理する列挙子を返します
    /// </summary>
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return mList.GetEnumerator();
    }

    /// <summary>
    /// リストを反復処理する列挙子を返します
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return mList.GetEnumerator();
    }

    /// <summary>
    /// 値が変更された時に呼び出されます
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