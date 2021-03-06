﻿using BrightIdeasSoftware;
using Microsoft.CodeAnalysis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPad.CodeAnalysis
{
    abstract internal class SyntaxWrapper
    {
        public static SyntaxWrapper Get(object syntax)
        {
            if (syntax is SyntaxNode)
            {
                return new SyntaxNodeWrapper((SyntaxNode)syntax);
            }
            if (syntax is SyntaxToken)
            {
                return new SyntaxTokenWrapper((SyntaxToken)syntax);
            }
            if (syntax is SyntaxTrivia)
            {
                return new SyntaxTriviaWrapper((SyntaxTrivia)syntax);
            }
            if (syntax is SyntaxNodeOrToken)
            {
                if (((SyntaxNodeOrToken)syntax).IsNode)
                {
                    return new SyntaxNodeWrapper(((SyntaxNodeOrToken)syntax).AsNode());
                }
                return new SyntaxTokenWrapper(((SyntaxNodeOrToken)syntax).AsToken());
            }
            return null;
        }

        public abstract object GetSyntaxObject();

        public abstract bool CanExpand();
        public abstract IEnumerable GetChildren();

        public abstract void FormatCell(FormatCellEventArgs format);
        public abstract string GetKind();
        public abstract string GetSpan();
        public abstract string GetText();
    }
}
