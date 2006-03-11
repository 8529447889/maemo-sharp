
TARGETS = basic.exe hello-world.exe calendar.exe

EXTRA_DIST = BasicSample.cs HelloWorld.cs CalendarApp.cs gorilla.png

DEBUGS = $(addsuffix .mdb, $(TARGETS))

CLEANFILES = $(TARGETS) $(DEBUGS)

references=-r:../hildon/hildon-sharp.dll -r:../libosso/libosso-sharp.dll -pkg:gtk-sharp-2.0

all: $(TARGETS)

basic.exe: $(srcdir)/BasicSample.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/BasicSample.cs

hello-world.exe: $(srcdir)/HelloWorld.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/HelloWorld.cs

calendar.exe: $(srcdir)/CalendarApp.cs
	$(CSC)  /out:$@ $(references) $(srcdir)/CalendarApp.cs
