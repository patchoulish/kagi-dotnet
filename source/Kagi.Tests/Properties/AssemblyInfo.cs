using Microsoft;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(
	Scope = ExecutionScope.ClassLevel)]
