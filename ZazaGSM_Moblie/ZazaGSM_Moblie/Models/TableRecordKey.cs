﻿using System;

namespace ZazaGSM_Moblie.Models
{
    public class TableRecordKey : RecordKey
    {
        public TableRecordKey(int? id)
        {
            Id = id;
        }

        public int? Id { get; }

        public override bool Equals(RecordKey other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (other.GetType() != typeof(TableRecordKey))
                throw new ArgumentException($"Unexpected argument in {nameof(TableRecordKey)}.{nameof(Equals)}");

            TableRecordKey otherKey = (TableRecordKey)other;
            return Id == otherKey.Id;
        }

        public static string Null => "NULL";

        public override string ToString()
        {
            if (Id == null)
                return "NULL";
            return ((int)Id).ToString();
        }

        public static bool operator ==(TableRecordKey left, TableRecordKey right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(TableRecordKey left, TableRecordKey right)
        {
            return !left.Equals(right);
        }
    }
}