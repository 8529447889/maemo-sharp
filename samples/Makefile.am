
TARGETS = basic.exe hello-world.exe calendar.exe banner.exe findbar.exe

EXTRA_DIST = BasicSample.cs HelloWorld.cs CalendarApp.cs Banner.cs FindBar.cs gorilla.png

DEBUGS = $(addsuffix .mdb, $(TARGETS))

CLEANFILES = $(TARGETS) $(DEBUGS)

references=-r:../maemo/maemo-sharp.dll -pkg:gtk-sharp-2.0

all: $(TARGETS)

basic.exe: $(srcdir)/BasicSample.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/BasicSample.cs

hello-world.exe: $(srcdir)/HelloWorld.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/HelloWorld.cs

calendar.exe: $(srcdir)/CalendarApp.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/CalendarApp.cs

banner.exe: $(srcdir)/Banner.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/Banner.cs

findbar.exe: $(srcdir)/FindBar.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/FindBar.cs
