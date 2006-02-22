
pkgconfigdir = $(libdir)/pkgconfig
pkgconfig_DATA = libosso-sharp.pc

MCS=mcs

ASSEMBLY_NAME= libosso-sharp
ASSEMBLY= $(ASSEMBLY_NAME).dll

sources = Osso.cs

build_sources = AssemblyInfo.cs $(sources)

CLEANFILES = libosso-sharp.dll

DISTCLEANFILES= AssemblyInfo.cs libosso-sharp.dll.config libosso-sharp.pc

noinst_DATA = libosso-sharp.dll

all: libosso-sharp.dll

libosso-sharp.dll: $(build_sources)
	$(MCS) -nowarn:169 -unsafe -target:library $(GTK_SHARP_LIBS) \
	$(build_sources) -out:libosso-sharp.dll

install-data-local:
	echo "$(GACUTIL) /i $(ASSEMBLY) /f $(GACUTIL_FLAGS)";  \
        $(GACUTIL) /i $(ASSEMBLY) /f $(GACUTIL_FLAGS) || exit 1;

uninstall-local:
	echo "$(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS)"; \
        $(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS) || exit 1;

EXTRA_DIST = $(sources) AssemblyInfo.cs.in libosso-sharp.dll.config.in libosso-sharp.pc.in
