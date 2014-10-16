//
// This file causes a build-time exception when PostSharp is not included in the build process.
// To avoid false errors, do not open the file in Visual Studio, and ignore any error real-time 
// verifiers such as Resharper may report.
//
// You can safely delete this file, but it will be recreated when you upgrade the NuGet package.
//

#if !POSTSHARP
#error PostSharp is not introduced in the build process. If NuGet just restored the PostSharp package, you need to rebuild the solution.
#endif