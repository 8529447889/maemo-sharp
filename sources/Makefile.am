
SVN_ROOT = https://stage.maemo.org/svn/maemo/projects/haf/tags

SOURCE_DIRS = \
	hildon-lgpl \
	hildon-libs \
	hildon-fm

EXTRA_DIST = maemo-sharp-sources.xml

api:
	PERLLIB=$(GTKSHARP_PREFIX)/share/perl5 \
	PATH=$(GTKSHARP_PREFIX)/bin:$$PATH \
	gapi2-parser maemo-sharp-sources.xml

get-sources:
	@for i in $(SOURCE_DIRS); do                                              \
		rm -rf $$i ;                                                      \
		svn checkout $(SVN_ROOT)/$$i/`pkg-config --modversion $$i`-1 $$i; \
	done;

clean:
	@for i in $(SOURCE_DIRS); do \
		rm -rf $$i ;         \
	done;
