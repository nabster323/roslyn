﻿using System.Threading.Tasks;
using Roslyn.Test.Utilities;
using Xunit;

namespace Microsoft.CodeAnalysis.Editor.CSharp.UnitTests.AddBraces
{
    public partial class AddBracesTests
    {
        [Fact]
        [Trait(Traits.Feature, Traits.Features.CodeActionsAddBraces)]
        [Trait(Traits.Feature, Traits.Features.CodeActionsFixAllOccurrences)]
        public async Task TestFixAllInDocument()
        {
            var input = @"
<Workspace>
    <Project Language=""C#"" AssemblyName=""Assembly1"" CommonReferences=""true"">
        <Document>
class Program1
{
    static void Main()
    {
        {|FixAllInDocument:if|} (true) return;
        if (true) return;
    }
}
        </Document>
        <Document>
class Program2
{
    static void Main()
    {
        if (true) return;
    }
}
        </Document>
    </Project>
    <Project Language=""C#"" AssemblyName=""Assembly2"" CommonReferences=""true"">
        <Document>
class Program3
{
    static void Main()
    {
        if (true) return;
    }
}
        </Document>
    </Project>
</Workspace>";

            var expected = @"
<Workspace>
    <Project Language=""C#"" AssemblyName=""Assembly1"" CommonReferences=""true"">
        <Document>
class Program1
{
    static void Main()
    {
        if (true)
        {
            return;
        }

        if (true)
        {
            return;
        }
    }
}
        </Document>
        <Document>
class Program2
{
    static void Main()
    {
        if (true) return;
    }
}
        </Document>
    </Project>
    <Project Language=""C#"" AssemblyName=""Assembly2"" CommonReferences=""true"">
        <Document>
class Program3
{
    static void Main()
    {
        if (true) return;
    }
}
        </Document>
    </Project>
</Workspace>";

            await TestAsync(input, expected, compareTokens: false, fixAllActionEquivalenceKey: null);
        }

        [Fact]
        [Trait(Traits.Feature, Traits.Features.CodeActionsAddBraces)]
        [Trait(Traits.Feature, Traits.Features.CodeActionsFixAllOccurrences)]
        public async Task TestFixAllInProject()
        {
            var input = @"
<Workspace>
    <Project Language=""C#"" AssemblyName=""Assembly1"" CommonReferences=""true"">
        <Document>
class Program1
{
    static void Main()
    {
        {|FixAllInProject:if|} (true) return;
    }
}
        </Document>
        <Document>
class Program2
{
    static void Main()
    {
        if (true) return;
    }
}
        </Document>
    </Project>
    <Project Language=""C#"" AssemblyName=""Assembly2"" CommonReferences=""true"">
        <Document>
class Program3
{
    static void Main()
    {
        if (true) return;
    }
}
        </Document>
    </Project>
</Workspace>";

            var expected = @"
<Workspace>
    <Project Language=""C#"" AssemblyName=""Assembly1"" CommonReferences=""true"">
        <Document>
class Program1
{
    static void Main()
    {
        if (true)
        {
            return;
        }
    }
}
        </Document>
        <Document>
class Program2
{
    static void Main()
    {
        if (true)
        {
            return;
        }
    }
}
        </Document>
    </Project>
    <Project Language=""C#"" AssemblyName=""Assembly2"" CommonReferences=""true"">
        <Document>
class Program3
{
    static void Main()
    {
        if (true) return;
    }
}
        </Document>
    </Project>
</Workspace>";

            await TestAsync(input, expected, compareTokens: false, fixAllActionEquivalenceKey: null);
        }

        [Fact]
        [Trait(Traits.Feature, Traits.Features.CodeActionsAddBraces)]
        [Trait(Traits.Feature, Traits.Features.CodeActionsFixAllOccurrences)]
        public async Task TestFixAllInSolution()
        {
            var input = @"
<Workspace>
    <Project Language=""C#"" AssemblyName=""Assembly1"" CommonReferences=""true"">
        <Document>
class Program1
{
    static void Main()
    {
        {|FixAllInSolution:if|} (true) return;
    }
}
        </Document>
        <Document>
class Program2
{
    static void Main()
    {
        if (true) return;
    }
}
        </Document>
    </Project>
    <Project Language=""C#"" AssemblyName=""Assembly2"" CommonReferences=""true"">
        <Document>
class Program3
{
    static void Main()
    {
        if (true) return;
    }
}
        </Document>
    </Project>
</Workspace>";

            var expected = @"
<Workspace>
    <Project Language=""C#"" AssemblyName=""Assembly1"" CommonReferences=""true"">
        <Document>
class Program1
{
    static void Main()
    {
        if (true)
        {
            return;
        }
    }
}
        </Document>
        <Document>
class Program2
{
    static void Main()
    {
        if (true)
        {
            return;
        }
    }
}
        </Document>
    </Project>
    <Project Language=""C#"" AssemblyName=""Assembly2"" CommonReferences=""true"">
        <Document>
class Program3
{
    static void Main()
    {
        if (true)
        {
            return;
        }
    }
}
        </Document>
    </Project>
</Workspace>";

            await TestAsync(input, expected, compareTokens: false, fixAllActionEquivalenceKey: null);
        }
    }
}
