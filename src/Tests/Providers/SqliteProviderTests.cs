﻿using SqlFu.Providers;
using Xunit;
using System;
using System.Diagnostics;

namespace Tests.Providers
{
    public class SqliteProviderTests
    {
        private Stopwatch _t = new Stopwatch();

        public SqliteProviderTests()
        {

        }

        [Fact]
        public void already_escaped_id_are_not_escaped()
        {
            Assert.Equal("\"public.table\"", SqliteProvider.EscapeIdentifier("\"public.table\""));
            Assert.Equal("\"my table\"", SqliteProvider.EscapeIdentifier("\"my table\""));
        }

        [Fact]
        public void common_escaping()
        {
            Assert.Equal("\"mytable\"", SqliteProvider.EscapeIdentifier("mytable"));
            Assert.Equal("\"my table\"", SqliteProvider.EscapeIdentifier("my table"));
        }

        [Fact]
        public void anything_with_dot_will_be_escaped_as_schema_table()
        {
            Assert.Equal("\"public\".\"mytable\"", SqliteProvider.EscapeIdentifier("public.mytable"));
        }

        protected void Write(string format, params object[] param)
        {
            Console.WriteLine(format, param);
        }
    }
}